using OfertaFone.WebUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewModels.Components
{
    public class LayoutNavBarViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool Enabled { get; set; }
        public string Image { get; set; }
    }
}
