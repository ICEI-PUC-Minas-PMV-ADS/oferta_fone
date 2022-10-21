using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Utils.Extensions
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetSecret(this IConfiguration configuration, string property)
        {
            var clienteKeyVault = new SecretClient(vaultUri: new Uri(configuration.GetSection("KeyVault").GetSection("URISecret").Value), credential: new DefaultAzureCredential());
            KeyVaultSecret secret = clienteKeyVault.GetSecret(property);
            return secret.Value;
        }
    }
}
