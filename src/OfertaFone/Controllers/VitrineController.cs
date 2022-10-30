using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Utils.Attributes;
using OfertaFone.WebUI.ViewModels.Components;
using OfertaFone.WebUI.ViewModels.Vitrine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.Controllers
{
    public class VitrineController : BaseController
    {
        private readonly IRepository<ProdutoEntity> _produtoRepository;
        private readonly IMapper _imapper;

        public VitrineController(
            IRepository<ProdutoEntity> produtoRepository,
            IMapper imapper)
        {
            this._produtoRepository = produtoRepository;
            this._imapper = imapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
        {
            var catalogQuery = _produtoRepository.Table.AsQueryable();

            var catalog = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.Like(x.Modelo, $"%{q}%"))
                                            .OrderBy(x => x.Modelo)
                                            .Skip(ps * (page - 1))
                                            .Take(ps)
                                            .ToListAsync();

            var listView = catalog.Select(entity => _imapper.Map<IndexViewModel>(entity));

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
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(_imapper.Map<DetailsViewModel>(await _produtoRepository.FindById(id)));
        }
    }
}
