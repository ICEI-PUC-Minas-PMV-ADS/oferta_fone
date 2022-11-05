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
using OfertaFone.WebUI.ViewModels.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly IRepository<Pedido> _pedidoRepository;
        private readonly IMapper _imapper;

        public PedidoController(
            IRepository<Pedido> pedidoRepository,
            IMapper imapper)
        {
            this._pedidoRepository = pedidoRepository;
            this._imapper = imapper;
        }

        [HttpGet, Authorize, SessionExpire]
        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidoRepository.Table
                .Include(p => p.ItemPedido)
                .ThenInclude(p => p.Produto)
                .Where(pedido => pedido.Status == TipoPedidoStatus._FINALIZADO && pedido.UsuarioId == HttpContext.Session.Get<int>("UserId"))
                .ToListAsync();

            pedidos ??= new List<Pedido>();

            var model = pedidos.Select(pedido =>
                  new IndexViewModel
                  {
                      Id = pedido.Id,
                      Total = pedido.Total,
                      QuantidadeItens = pedido.QuantidadeItens,
                      Produtos = pedido.ItemPedido != null && pedido.ItemPedido.Any() ?
                      pedido.ItemPedido.Select(itempedido => _imapper.Map<ViewModels.Vitrine.DetailsViewModel>(itempedido.Produto)).ToList() :
                      new List<ViewModels.Vitrine.DetailsViewModel>()
                  }
            ).ToList();

            return View(model);
        }
    }
}
