using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfertaFone.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OfertaFone.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
