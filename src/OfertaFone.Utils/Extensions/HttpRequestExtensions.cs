using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfertaFone.Domain.Interfaces;

namespace OfertaFone.Utils.Extensions
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="fileStorage"></param>
        /// <param name="fileDefault"></param>
        /// <returns></returns>
        public async static Task<string> UploadFile(this HttpRequest Request, IFileStorage fileStorage, string fileDefault = null)
        {
            string UrlImg = fileDefault;
            if (Request.Form != null && Request.Form.Files != null && Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                UrlImg = await fileStorage.UploadAsync(file.OpenReadStream(), file.Name, file.ContentType);
            }

            return UrlImg;
        }
    }
}
