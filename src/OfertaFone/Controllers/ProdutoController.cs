using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Utils.Attributes;
using OfertaFone.WebUI.ViewModels.Produto;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IRepository<ProdutoEntity> produtoRepository;

        public ProdutoController(IRepository<ProdutoEntity> produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var entity = await produtoRepository.FindAll();
            return View(entity.Select(entity => new IndexViewModel() { Preco = entity.Preco, Id = entity.Id, Nome = entity.Nome }));
        }

        // GET: ProdutoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var entity = await produtoRepository.FindById(id);
            return View(new DetailsViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Preco = entity.Preco,
                Descricao = entity.Descricao,
                Image = entity.Image,
                Ativo = entity.Ativo,
                UsuarioId = entity.UsuarioId           
            });
        }

        // GET: ProdutoController/Create
        [HttpGet, Authorize, SessionExpire]
        public ActionResult Create()
        {
            return View(new CreateViewModel());
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
