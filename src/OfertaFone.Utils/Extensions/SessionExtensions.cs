using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text.Json;

namespace OfertaFone.Utils.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            if (session.Keys.Contains(key))
            {
                var value = session.GetString(key);
                return value == null ? default : JsonSerializer.Deserialize<T>(value);
            }
            else
            {
                return default;
            }

        }
    }
}
