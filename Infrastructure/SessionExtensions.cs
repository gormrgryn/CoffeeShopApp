// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Session;
// using System.Text.Json;
// using CoffeeShopApp.Models;

// namespace CoffeeShopApp.Infrastructure
// {
//     public static class SessionExtensions
//     {
//         public static void SetJson(this ISession session, string key, Basket basket)
//         {
//             session.SetString(key, JsonSerializer.Serialize(basket));
//         }
//         public static T GetJson<T>(this ISession session, string key)
//         {
//             var sessionData = session.GetString(key);
//             return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
//         }
//     }
// }
