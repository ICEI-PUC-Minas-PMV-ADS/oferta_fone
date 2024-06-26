﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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
    /// Esta classe implementa o upload de arquivos
    /// no Azure Blob Storage
    /// </summary>
    public class BlobStorageServiceAzure : IFileStorage
    {
        private readonly BlobServiceClient _blobServiceClient;
        private const string CONTAINER_NAME = "publicuploads";

        public BlobStorageServiceAzure(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="Name"></param>
        /// <param name="ContentType"></param>
        /// <returns></returns>
        public async Task<string> UploadAsync(Stream Content, string Name, string ContentType)
        {
            if (Content == null)
            {
                return null;
            }

            var containerClient = _blobServiceClient.GetBlobContainerClient(CONTAINER_NAME);

            var blobClient = containerClient.GetBlobClient(GetPathWithFileName(Name));

            await blobClient.UploadAsync(Content, new BlobHttpHeaders { ContentType = ContentType });

            return blobClient.Uri.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private string GetPathWithFileName(string Name)
        {
            string uniqueAutoGeneratedFileName = Path.GetRandomFileName();
            string shortClientSideFileNameWithoutExt = Path.GetFileNameWithoutExtension(Name);  //Trimming to max 10 as client side file name can be too long
            string ext = Path.GetExtension(Name);
            string basePath = "stories/";

            return basePath + uniqueAutoGeneratedFileName + "_" + shortClientSideFileNameWithoutExt + ext;
        }
    }
}
