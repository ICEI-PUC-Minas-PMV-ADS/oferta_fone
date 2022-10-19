using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewComponents
{
    [ViewComponent(Name = "carrinho")]
    public class CarrinhoViewComponent : ViewComponent
    {

        public CarrinhoViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // TODO: Realizar chamada no banco
            return View(1);
        }
    }
}
