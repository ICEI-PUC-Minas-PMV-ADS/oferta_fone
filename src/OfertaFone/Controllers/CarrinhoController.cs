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

        [HttpGet, Authorize, SessionExpire]
        public async Task<IActionResult> Index()
        {
            var pedido = await _pedidoRepository.Table
                .Include(p => p.ItemPedido)
                .ThenInclude(p => p.Produto)
                .Where(pedido => pedido.Status == true && pedido.UsuarioId == HttpContext.Session.Get<int>("UserId"))
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

        [HttpGet, Authorize, SessionExpire]
        public IActionResult Adicionar(int id)
        {
            return RedirectToAction("Details", "Vitrine", new { id });
        }

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
                    .Where(pedido => pedido.Status == true && pedido.UsuarioId == HttpContext.Session.Get<int>("UserId"))
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
                        Status = true,
                        QuantidadeItens = 1,
                        Total = produto.Preco,
                        UsuarioId = HttpContext.Session.Get<int>("UserId")
                    };

                    await _pedidoRepository.Insert(pedido);
                    await _pedidoRepository.CommitAsync();
                }

                var itemPedido = new ItemPedido();
                itemPedido.PedidoId = pedido.Id;
                itemPedido.ProdutoId = produto.Id;

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
    }
}
