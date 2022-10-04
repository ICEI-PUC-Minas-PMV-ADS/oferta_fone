using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OfertaFone.Utils.Extensions;

namespace OfertaFone.Utils.Attributes
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Checa se um usuário está logado na aplicação
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ISession session = filterContext.HttpContext.Session;

            if (string.IsNullOrEmpty(session.Get<int>("UserId").ToString()) || session.Get<int>("UserId") == 0)
            {
                filterContext.Result = new RedirectToActionResult("Login", "Account", new { });
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
