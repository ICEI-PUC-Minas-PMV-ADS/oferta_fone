using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Utils.Extensions
{
    public static class IWebHostEnvironmentExtensions
    {
        /// <summary>
        /// Verifica se o ambiente é o de desenvolvimento
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        /// <returns></returns>
        public static bool IsDevelopment(this IWebHostEnvironment webHostEnvironment)
        {
            return "Development".Equals(webHostEnvironment.EnvironmentName);
        }
    }
}
