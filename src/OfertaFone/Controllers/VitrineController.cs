using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.WebUI.ViewModels.Components;
using OfertaFone.WebUI.ViewModels.Vitrine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.Controllers
{
    public class VitrineController : Controller
    {
        private readonly IRepository<ProdutoEntity> produtoRepository;

        public VitrineController(IRepository<ProdutoEntity> produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
        {
            var catalogQuery = produtoRepository.Table.AsQueryable();

            var catalog = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.Like(x.Modelo, $"%{q}%"))
                                            .OrderBy(x => x.Modelo)
                                            .Skip(ps * (page - 1))
                                            .Take(ps)
                                            .ToListAsync();

            var listView = catalog.Select(entity => new IndexViewModel() { Preco = entity.Preco, Id = entity.Id, Nome = entity.Modelo, Image = entity.Image });

            var total = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                          .Where(x => EF.Functions.Like(x.Modelo, $"%{q}%"))
                                          .CountAsync();

            return View(new PagedViewModel<IndexViewModel>()
            {
                List = listView,
                TotalResults = total,
                PageIndex = page,
                PageSize = ps,
                Query = q
            });
        }

        // GET: ProdutoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var entity = await produtoRepository.FindById(id);
            return View(new DetailsViewModel
            {
                Id = entity.Id,
                Preco = entity.Preco,
                Descricao = entity.Descricao,
                Image = entity.Image,
                UsuarioId = entity.UsuarioId,
                Modelo = entity.Modelo,
                Marca = entity.Marca,
                Memoria = entity.Memoria,
                Camera = entity.Camera,
                Processador = entity.Processador,
                RAM = entity.RAM
            });
        }

        // GET: VitrineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VitrineController/Create
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

        // GET: VitrineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VitrineController/Edit/5
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

        // GET: VitrineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VitrineController/Delete/5
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
