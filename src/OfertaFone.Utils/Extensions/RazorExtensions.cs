using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Utils.Extensions
{
    public static class RazorExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string HashForGravatar(string chave)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(chave));
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string FormatMoney(this RazorPage page, decimal valor)
        {
            return FormatMoney(valor);
        }

        public static string FormatFraseItem(this RazorPage page, int quantidade)
        {
            return quantidade > 1 ? $"{quantidade} - itens" : $"{quantidade} - item";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private static string FormatMoney(decimal valor)
        {
            return string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
        }
    }
}
