using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Utils.Attributes;
using OfertaFone.Utils.Extensions;
using OfertaFone.WebUI.Tipo;
using OfertaFone.WebUI.ViewModels.Produto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IRepository<ProdutoEntity> produtoRepository;
        private readonly IFileStorage fileStorage;

        public ProdutoController(IRepository<ProdutoEntity> _produtoRepository, IFileStorage _fileStorage)
        {
            this.produtoRepository = _produtoRepository;
            this.fileStorage = _fileStorage;
        }

        // GET: ProdutoController
        [HttpGet, Authorize, SessionExpire]
        public async Task<IActionResult> Index()
        {
            var entity = await produtoRepository.Table.Where(produto => 
                produto.UsuarioId == HttpContext.Session.Get<int>("UserId")
            ).ToListAsync();

            var model = new IndexViewModel()
            {
                IndexTableViewModels = entity.Select(produto =>
                   new IndexTableViewModel()
                   {
                       Id = produto.Id,
                       Marca = produto.Marca,
                       Modelo = produto.Modelo,
                       Image = produto.Image,
                       Status = produto.Ativo
                   }).ToList()
            };

            return View(model);
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
                    string UrlImg = TipoImagensPadrao._PRODUTO;

                    if (Request.Form != null && Request.Form.Files != null && Request.Form.Files.Count > 0)
                    {
                        var file = Request.Form.Files[0];
                        UrlImg = await fileStorage.UploadAsync(file.OpenReadStream(), file.Name, file.ContentType);
                    }

                    var produtoEntity = new ProdutoEntity()
                    {
                        Marca = createViewModel.Marca,
                        Modelo = createViewModel.Modelo,
                        Processador = createViewModel.Processador,
                        Memoria = createViewModel.Memoria,
                        Camera = createViewModel.Camera,
                        RAM = createViewModel.RAM,
                        Preco = createViewModel.Preco,
                        Descricao = createViewModel.Descricao,
                        Ativo = true,
                        Image = UrlImg,
                        UsuarioId = HttpContext.Session.Get<int>("UserId")
                    };

                    await produtoRepository.Insert(produtoEntity);
                    await produtoRepository.CommitAsync();

                    AddSuccess("Produto registrado com sucesso!");
                    return RedirectToAction("Create", "Produto");
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
