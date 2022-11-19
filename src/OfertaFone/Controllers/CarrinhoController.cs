using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Utils.Attributes;
using OfertaFone.Utils.Exceptions;
using OfertaFone.Utils.Extensions;
using OfertaFone.WebUI.Tipo;
using OfertaFone.WebUI.ViewModels.Base;
using OfertaFone.WebUI.ViewModels.Carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.Controllers
{
    public class CarrinhoController : BaseController
    {
        private readonly IRepository<ProdutoEntity> _produtoRepository;
        private readonly IRepository<Pedido> _pedidoRepository;
        private readonly IRepository<ItemPedido> _itemPedidoRepository;
        private readonly IMapper _imapper;

        public CarrinhoController(
            IRepository<ProdutoEntity> produtoRepository,
            IRepository<Pedido> pedidoRepository,
            IRepository<ItemPedido> itemPedidoRepository,
            IMapper imapper)
        {
            this._produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
            this._itemPedidoRepository = itemPedidoRepository;
            this._imapper = imapper;
        }

        // GET: CarrinhoController
        [HttpGet, Authorize, SessionExpire]
        public async Task<IActionResult> Index()
        {
            var pedido = await _pedidoRepository.Table
                .Include(p => p.ItemPedido)
                .ThenInclude(p => p.Produto)
                .Where(pedido => pedido.Status == TipoPedidoStatus._NAO_FINALIZADO && pedido.UsuarioId == HttpContext.Session.Get<int>("UserId"))
                .SingleOrDefaultAsync();

            pedido ??= new Pedido();

            var model = new IndexViewModel
            {
                Total = pedido.Total,
                QuantidadeItens = pedido.QuantidadeItens,
                Produtos = pedido.ItemPedido != null && pedido.ItemPedido.Any() ?
                    pedido.ItemPedido.Select(itempedido => _imapper.Map<ViewModels.Vitrine.DetailsViewModel>(itempedido.Produto)).ToList() :
                    new List<ViewModels.Vitrine.DetailsViewModel>()
            };

            return View(model);
        }

        // GET: CarrinhoController/Adicionar/5
        [HttpGet, Authorize, SessionExpire]
        public IActionResult Adicionar(int id)
        {
            return RedirectToAction("Details", "Vitrine", new { id });
        }

        // POST: CarrinhoController/Adicionar/{baseViewModel}
        [HttpPost, Authorize, SessionExpire]
        public async Task<IActionResult> Adicionar(BaseViewModel baseViewModel)
        {
            try
            {
                var produto = await _produtoRepository.Table
                    .Where(p => p.Id == baseViewModel.Id)
                    .SingleOrDefaultAsync();

                if (produto == null)
                {
                    throw new LogicalException("Produto não encontrado.");
                }

                var pedido = await _pedidoRepository.Table
                    .Where(pedido => pedido.Status == TipoPedidoStatus._NAO_FINALIZADO && pedido.UsuarioId == HttpContext.Session.Get<int>("UserId"))
                    .SingleOrDefaultAsync();

                if (pedido != null)
                {
                    var itemPedidos = await _itemPedidoRepository.Table
                        .Where(i => i.PedidoId == pedido.Id && i.ProdutoId == produto.Id)
                        .SingleOrDefaultAsync();

                    if (itemPedidos != null)
                    {
                        throw new LogicalException("Este item já se encontra no carrinho.");
                    }

                    pedido.QuantidadeItens += 1;
                    pedido.Total += produto.Preco;

                    await _pedidoRepository.Update(pedido);
                    await _pedidoRepository.CommitAsync();
                }
                else
                {
                    pedido = new Pedido
                    {
                        Status = TipoPedidoStatus._NAO_FINALIZADO,
                        QuantidadeItens = 1,
                        Total = produto.Preco,
                        UsuarioId = HttpContext.Session.Get<int>("UserId")
                    };

                    await _pedidoRepository.Insert(pedido);
                    await _pedidoRepository.CommitAsync();
                }

                var itemPedido = new ItemPedido
                {
                    PedidoId = pedido.Id,
                    ProdutoId = produto.Id
                };

                await _itemPedidoRepository.Insert(itemPedido);
                await _itemPedidoRepository.CommitAsync();
                return RedirectToAction("Index", "Carrinho");
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }
            return RedirectToAction("Details", "Vitrine", new { id = baseViewModel.Id });
        }

        // POST: CarrinhoController/Deletar/5
        [HttpPost, Authorize, SessionExpire]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var produto = await _produtoRepository.FindById(id);

                var pedido = await _pedidoRepository.Table
                    .Include(p => p.ItemPedido)
                    .ThenInclude(p => p.Produto)
                    .Where(pedido => pedido.Status == TipoPedidoStatus._NAO_FINALIZADO && pedido.UsuarioId == HttpContext.Session.Get<int>("UserId"))
                    .SingleOrDefaultAsync();

                // Atualiza o pedido subtraindo o valor do produto que está sendo excluído
                pedido.QuantidadeItens -= 1;
                pedido.Total -= produto.Preco;

                // busca o item que esteja ligado ao produto para remover
                var itemPedido = pedido.ItemPedido.Where(itemPedido => itemPedido.ProdutoId == id).FirstOrDefault();

                await _itemPedidoRepository.Delete(itemPedido);
                await _itemPedidoRepository.CommitAsync();

                await _pedidoRepository.Update(pedido);
                await _pedidoRepository.CommitAsync();

                AddSuccess("Produto removido do carrinho com sucesso!");
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }
            return RedirectToAction("Index", "Carrinho");
        }
    }
}
