using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Utils.Attributes;
using OfertaFone.WebUI.ViewModels.Components;
using OfertaFone.WebUI.ViewModels.Produto;
using System;
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

        public async Task<IActionResult> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
        {
            var catalogQuery = produtoRepository.Table.AsQueryable();

            var catalog = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.Like(x.Nome, $"%{q}%"))
                                            .OrderBy(x => x.Nome)
                                            .Skip(ps * (page - 1))
                                            .Take(ps)
                                            .ToListAsync();

            var listView = catalog.Select(entity => new IndexViewModel() { Preco = entity.Preco, Id = entity.Id, Nome = entity.Nome });

            var total = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                          .Where(x => EF.Functions.Like(x.Nome, $"%{q}%"))
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
        public ActionResult Details(int id)
        {
            return View();
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
                if(ModelState.IsValid)
                {
                    var produtoEntity = new ProdutoEntity()
                    {
                        Preco = createViewModel.Preco,
                    };
                    await produtoRepository.Insert(produtoEntity);
                    await produtoRepository.CommitAsync();

                    AddSuccess("User registered successfully");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch(Exception ex)
            {
                TratarException(ex);
            }
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
