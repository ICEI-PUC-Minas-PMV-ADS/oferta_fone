using Microsoft.AspNetCore.Mvc;
using OfertaFone.WebUI.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewComponents
{
    [ViewComponent(Name = "paging")]
    public class PagingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedList pagingModel)
        {
            return View(pagingModel);
        }
    }
}
