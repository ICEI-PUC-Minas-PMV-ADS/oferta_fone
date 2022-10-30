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
using OfertaFone.WebUI.ViewModels.Base;
using OfertaFone.WebUI.ViewModels.Produto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IRepository<ProdutoEntity> _produtoRepository;
        private readonly IFileStorage _fileStorage;
        private readonly IMapper _imapper;

        public ProdutoController(
            IRepository<ProdutoEntity> produtoRepository, 
            IFileStorage fileStorage, 
            IMapper imapper)
        {
            this._produtoRepository = produtoRepository;
            this._fileStorage = fileStorage;
            this._imapper = imapper;
        }

        // GET: ProdutoController
        [HttpGet, Authorize, SessionExpire]
        public async Task<IActionResult> Index()
        {
            var entity = await _produtoRepository.Table.Where(produto =>
                produto.UsuarioId == HttpContext.Session.Get<int>("UserId")
            ).ToListAsync();

            var model = new IndexViewModel()
            {
                IndexTableViewModels = entity.Select(produto =>
                    _imapper.Map<IndexTableViewModel>(produto)).ToList()
            };

            return View(model);
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
                    string UrlImg = await Request.UploadFile(fileStorage: _fileStorage, fileDefault: TipoImagensPadrao._PRODUTO);
                    
                    var produtoEntity = _imapper.Map<ProdutoEntity>(createViewModel);
                    produtoEntity.Ativo = true;
                    produtoEntity.Image = UrlImg;
                    produtoEntity.UsuarioId = HttpContext.Session.Get<int>("UserId");

                    await _produtoRepository.Insert(produtoEntity);
                    await _produtoRepository.CommitAsync();

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
            return View(_imapper.Map<EditViewModel>(await _produtoRepository.FindById(id)));
        }

        // GET: ProdutoController/Edit/5
        [HttpPost, Authorize, SessionExpire]
        public async Task<IActionResult> Edit(EditViewModel editViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UrlImg = await Request.UploadFile(fileStorage: _fileStorage);
                    var entity = await _produtoRepository.FindById(editViewModel.Id);

                    entity.Preco = editViewModel.Preco;
                    entity.Descricao = editViewModel.Descricao;
                    entity.Modelo = editViewModel.Modelo;
                    entity.Marca = editViewModel.Marca;
                    entity.Processador = editViewModel.Processador;
                    entity.Memoria = editViewModel.Memoria;
                    entity.Camera = editViewModel.Camera;
                    entity.RAM = editViewModel.RAM;
                    entity.Image = UrlImg ?? entity.Image;

                    await _produtoRepository.Update(entity);
                    await _produtoRepository.CommitAsync();

                    AddSuccess("Produto editado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }
            return View(editViewModel);
        }
    }
}
