using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Utils.Attributes;
using OfertaFone.WebUI.ViewModels.Components;
using OfertaFone.Utils.Extensions;
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

        [HttpPost, Authorize, SessionExpire]
        public async Task<ActionResult> Create(CreateViewModel createViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var produtoEntity = new ProdutoEntity()
                    {
                        Marca = createViewModel.Marca,
                        Modelo = createViewModel.Modelo,
                        Processador = createViewModel.Processador,
                        Memoria = createViewModel.Memoria,
                        Camera = createViewModel.Camera,
                        RAM = createViewModel.RAM,
                        Preco = createViewModel.Preco,
                        Detalhes = createViewModel.Detalhes,
                        UsuarioId = HttpContext.Session.Get<int>("UserId")
                    };
                    await produtoRepository.Insert(produtoEntity);
                    await produtoRepository.CommitAsync();

                    AddSuccess("Produto registrado com sucesso!");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch(Exception ex)
            {
                TratarException(ex);
            }
            return View(new CreateViewModel());
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
