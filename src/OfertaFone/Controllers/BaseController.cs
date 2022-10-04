using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfertaFone.WebUI.ViewModels;
using System;
using System.Diagnostics;

namespace OfertaFone.WebUI.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public void TratarException(Exception ex)
        {
            AddError(JsonConvert.SerializeObject(ex));
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddError(string error)
        {
            TempData["success"] = null;
            TempData["warning"] = null;
            TempData["error"] = error;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddSuccess(string sucess)
        {
            TempData["success"] = sucess;
            TempData["warning"] = null;
            TempData["error"] = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddWarning(string warning)
        {
            TempData["success"] = null;
            TempData["warning"] = warning;
            TempData["error"] = null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
