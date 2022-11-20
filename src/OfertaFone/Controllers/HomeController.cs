using Microsoft.AspNetCore.Mvc;
using OfertaFone.WebUI.Controllers;
using Microsoft.AspNetCore.Http;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.WebUI.ViewModels.Home;
using System.Threading.Tasks;
using System.Linq;
using OfertaFone.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using OfertaFone.WebUI.Tipo;

namespace OfertaFone.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository<ProdutoEntity> _produtoRepository;
        private readonly IRepository<Pedido> _pedidoRepository;

        public HomeController(
            IRepository<ProdutoEntity> produtoRepository,
            IRepository<Pedido> pedidoRepository)
        {
            this._produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var entity = await _produtoRepository.Table.Where(produto =>
                produto.UsuarioId == HttpContext.Session.Get<int>("UserId")
            ).ToListAsync();

            var produtosVendidos = entity?.Where(produto => produto.Ativo == false);

            var model = new IndexViewModel()
            {
                LucroMensal = produtosVendidos?.Sum(produto => produto.Preco),
                LucroAnual = produtosVendidos?.Sum(produto => produto.Preco),
                PorcentagemProdutosVendidos = entity?.Count > 0 ? (int)(decimal.Divide(produtosVendidos.Count(), entity.Count) * 100) : 0,
                QuantidadeProdutosCadastrados = entity?.Count
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
