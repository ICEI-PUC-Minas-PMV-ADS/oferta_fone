using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OfertaFone.WebUI.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Roles = new List<string>();
            PasswordHash = "";
        }
        public IList<string> Roles { get; set; }
        public string Image { get; set; }
    }
}
