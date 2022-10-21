using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfertaFone.WebUI.Identity;
using OfertaFone.WebUI.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewComponents
{
    [ViewComponent(Name = "LoginPartial")]
    public class LoginPartialViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginPartialViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new LoginPartialViewModel();

            if (HttpContext.User.Identity != null && HttpContext.User.Identity.Name != null)
            {
                var appUser = await _userManager.FindByNameAsync(
                HttpContext.User.Identity.Name);

                vm.Image = appUser?.Image;
            }

            return View("../Shared/_LoginPartial.cshtml", vm);
        }
    }
}
