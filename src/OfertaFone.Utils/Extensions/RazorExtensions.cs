using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Utils.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatMoney(this RazorPage page, decimal valor)
        {
            return FormatMoney(valor);
        }

        private static string FormatMoney(decimal valor)
        {
            return string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
        }
    }
}
