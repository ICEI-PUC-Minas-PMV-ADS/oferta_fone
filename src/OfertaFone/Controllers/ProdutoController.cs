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
                    string UrlImg = await Request.UploadFile(fileStorage: fileStorage, fileDefault: TipoImagensPadrao._PRODUTO);

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
        [HttpGet, Authorize, SessionExpire]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await produtoRepository.FindById(id);
            return View(new EditViewModel
            {
                Id = entity.Id,
                Preco = entity.Preco,
                Descricao = entity.Descricao,
                Modelo = entity.Modelo,
                Marca = entity.Marca,
                Memoria = entity.Memoria,
                Camera = entity.Camera,
                Processador = entity.Processador,
                RAM = entity.RAM
            });
        }

        // GET: ProdutoController/Edit/5
        [HttpPost, Authorize, SessionExpire]
        public async Task<IActionResult> Edit(EditViewModel editViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UrlImg = await Request.UploadFile(fileStorage: fileStorage);
                    var entity = await produtoRepository.FindById(editViewModel.Id);

                    entity.Preco = editViewModel.Preco;
                    entity.Descricao = editViewModel.Descricao;
                    entity.Modelo = editViewModel.Modelo;
                    entity.Marca = editViewModel.Marca;
                    entity.Processador = editViewModel.Processador;
                    entity.Memoria = editViewModel.Memoria;
                    entity.Camera = editViewModel.Camera;
                    entity.RAM = editViewModel.RAM;
                    entity.Image = UrlImg ?? entity.Image;

                    await produtoRepository.Update(entity);
                    await produtoRepository.CommitAsync();

                    AddSuccess("Produto editado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }
            return View(editViewModel);
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
