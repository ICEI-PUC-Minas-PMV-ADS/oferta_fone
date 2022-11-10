using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Utils.Attributes;
using OfertaFone.Utils.Extensions;
using OfertaFone.WebUI.Tipo;
using OfertaFone.WebUI.ViewModels.Base;
using OfertaFone.WebUI.ViewModels.Produto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IRepository<ProdutoEntity> _produtoRepository;
        private readonly IRepository<Pedido> _pedidoRepository;
        private readonly IRepository<ItemPedido> _itemPedidoRepository;
        private readonly IFileStorage _fileStorage;
        private readonly IMapper _imapper;

        public ProdutoController(
            IRepository<ProdutoEntity> produtoRepository,
            IRepository<Pedido> pedidoRepository,
            IRepository<ItemPedido> itemPedidoRepository,
            IFileStorage fileStorage,
            IMapper imapper)
        {
            this._produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
            this._itemPedidoRepository = itemPedidoRepository;
            this._fileStorage = fileStorage;
            this._imapper = imapper;
        }

        // GET: ProdutoController
        [HttpGet, Authorize, SessionExpire]
        public async Task<IActionResult> Index()
        {
            var entity = await _produtoRepository.Table.Where(produto =>
                produto.UsuarioId == HttpContext.Session.Get<int>("UserId")
            ).ToListAsync();

            var model = new IndexViewModel()
            {
                IndexTableViewModels = entity.Select(produto =>
                    _imapper.Map<IndexTableViewModel>(produto)).ToList()
            };

            return View(model);
        }

        // POST: ProdutoController
        [HttpPost, Authorize, SessionExpire]
        public async Task<IActionResult> Index(IndexViewModel indexViewModel)
        {
            var entity = await _produtoRepository.Table.Where(produto =>
                produto.UsuarioId == HttpContext.Session.Get<int>("UserId") &&
                    (string.IsNullOrEmpty(indexViewModel.Modelo) || EF.Functions.Like(produto.Modelo, $"%{indexViewModel.Modelo}%")) &&
                    (string.IsNullOrEmpty(indexViewModel.Marca) || EF.Functions.Like(produto.Marca, $"%{indexViewModel.Marca}%"))
                ).ToListAsync();

            var model = new IndexViewModel()
            {
                IndexTableViewModels = entity.Select(produto =>
                    _imapper.Map<IndexTableViewModel>(produto)).ToList()
            };

            return View(model);
        }

        // GET: ProdutoController/Create
        [HttpGet, Authorize, SessionExpire]
        public ActionResult Create()
        {
            return View(new CreateViewModel());
        }

        [HttpPost, Authorize, SessionExpire]
        public async Task<ActionResult> Create(CreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UrlImg = await Request.UploadFile(fileStorage: _fileStorage, fileDefault: TipoImagensPadrao._PRODUTO);

                    var produtoEntity = _imapper.Map<ProdutoEntity>(createViewModel);
                    produtoEntity.Ativo = true;
                    produtoEntity.Image = UrlImg;
                    produtoEntity.UsuarioId = HttpContext.Session.Get<int>("UserId");

                    await _produtoRepository.Insert(produtoEntity);
                    await _produtoRepository.CommitAsync();

                    AddSuccess("Produto registrado com sucesso!");
                    return RedirectToAction("Create", "Produto");
                }
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }
            return View(new CreateViewModel());
        }

        // GET: ProdutoController/Edit/5
        [HttpGet, Authorize, SessionExpire]
        public async Task<IActionResult> Edit(int id)
        {
            return View(_imapper.Map<EditViewModel>(await _produtoRepository.FindById(id)));
        }

        // GET: ProdutoController/Edit/5
        [HttpPost, Authorize, SessionExpire]
        public async Task<IActionResult> Edit(EditViewModel editViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UrlImg = await Request.UploadFile(fileStorage: _fileStorage);
                    var entity = await _produtoRepository.FindById(editViewModel.Id);

                    var pedidos = await _pedidoRepository.Table
                        .Include(p => p.ItemPedido)
                        .ThenInclude(p => p.Produto)
                        .Where(pedido => pedido.Status == TipoPedidoStatus._NAO_FINALIZADO && pedido.ItemPedido.Any(itemPedido => itemPedido.ProdutoId == editViewModel.Id))
                        .ToListAsync();

                    foreach (var pedido in pedidos ?? Enumerable.Empty<Pedido>())
                    {
                        // subtrai o valor antigo e soma o novo valor
                        pedido.Total -= entity.Preco; // valor antigo
                        pedido.Total += editViewModel.Preco; // novo valor

                        await _pedidoRepository.Update(pedido);
                        await _pedidoRepository.CommitAsync();
                    }

                    entity.Preco = editViewModel.Preco;
                    entity.Descricao = editViewModel.Descricao;
                    entity.Modelo = editViewModel.Modelo;
                    entity.Marca = editViewModel.Marca;
                    entity.Processador = editViewModel.Processador;
                    entity.Memoria = editViewModel.Memoria;
                    entity.Camera = editViewModel.Camera;
                    entity.RAM = editViewModel.RAM;
                    entity.Image = UrlImg ?? entity.Image;

                    await _produtoRepository.Update(entity);
                    await _produtoRepository.CommitAsync();

                    AddSuccess("Produto editado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }
            return View(editViewModel);
        }

        // POST: ProdutoController/Edit/5
        [HttpPost, Authorize, SessionExpire]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto = await _produtoRepository.FindById(id);

                var pedidos = await _pedidoRepository.Table
                    .Include(p => p.ItemPedido)
                    .ThenInclude(p => p.Produto)
                    .Where(pedido => pedido.Status == TipoPedidoStatus._NAO_FINALIZADO && pedido.ItemPedido.Any(itemPedido => itemPedido.ProdutoId == id))
                    .ToListAsync();

                foreach(var pedido in pedidos ?? Enumerable.Empty<Pedido>())
                {
                    // Atualiza o pedido subtraindo o valor do produto que está sendo excluído
                    pedido.QuantidadeItens -= 1;
                    pedido.Total -= produto.Preco;

                    // busca o item que esteja ligado ao produto para remover
                    var itemPedido = pedido.ItemPedido.Where(itemPedido => itemPedido.ProdutoId == id).FirstOrDefault();

                    await _pedidoRepository.Update(pedido);
                    await _pedidoRepository.CommitAsync();

                    await _itemPedidoRepository.Delete(itemPedido);
                    await _itemPedidoRepository.CommitAsync();
                }

                await _produtoRepository.Delete(produto);
                await _produtoRepository.CommitAsync();

                AddSuccess("Produto removido com sucesso!");
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }
            return RedirectToAction("Index", "Produto");
        }
    }
}
