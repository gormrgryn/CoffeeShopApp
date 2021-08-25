using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using CoffeeShopApp.Models;

namespace CoffeeShopApp.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, Product product)
        {
            session.SetString(key, JsonConverter.SerializeObject(product));
        }
        public static Product GetJson(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(Product) : JsonConverter.DeserializeObject<Product>(sessionData);
        }
    }
}