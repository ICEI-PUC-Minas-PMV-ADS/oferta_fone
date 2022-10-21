using OfertaFone.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Utils.Service
{
    /// <summary>
    /// Esta classe implementa o upload de arquivos localmente
    /// </summary>
    public class BlobStorageServiceLocal : IFileStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="Name"></param>
        /// <param name="ContentType"></param>
        /// <returns></returns>
        public Task<string> UploadAsync(Stream Content, string Name, string ContentType)
        {
            return Task.FromResult("https://ofertafonestorageassets.blob.core.windows.net/publicuploads/user1/stories/galaxy.png");
        }
    }
}
