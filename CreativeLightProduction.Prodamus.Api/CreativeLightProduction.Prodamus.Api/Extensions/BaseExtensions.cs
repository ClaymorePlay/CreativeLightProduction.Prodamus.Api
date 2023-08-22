using CreativeLightProduction.Prodamus.Api.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Extensions
{
    /// <summary>
    /// Base extensions
    /// </summary>
    public static class BaseExtensions
    {
        /// <summary>
        /// Get signature for request
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static string GetSignature(this ISignatureModel obj, string secretKey)
        {
            var dict = GetDictionaryFromRequest(obj);
            var signature = Create(dict, secretKey);

            return signature;
        }


        /// <summary>
        /// Get key value from request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetDictionaryFromRequest<T>(T request)
        {
            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
            });

            var jObject = JObject.FromObject(request, new Newtonsoft.Json.JsonSerializer { NullValueHandling = NullValueHandling.Ignore });
            var date = jObject.Property("date");

            var model = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            if(model.ContainsKey("products"))
                model["products"] = JsonConvert.SerializeObject(model["products"]);

            if (date != null)
                model["date"] = date.Value.ToString();
            return model;
        }


        /// <summary>
        /// Create a signature
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="algo"></param>
        /// <returns></returns>
        private static string Create(Dictionary<string, object> data, string key)
        {

            data = StrValAndSort(data);

            var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                TypeNameHandling = TypeNameHandling.Arrays,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.None,
            });

            json = FixJsonSignature(json);


            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(json));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }


        /// <summary>
        /// Correcting json to form a hash
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private static string FixJsonSignature(string json)
        {
            json = json.Replace("\\", "");

            var startIndex = json.IndexOf("\"products\":");
            if (startIndex != -1)
            {
                var substring = json.Substring(startIndex);

                substring = substring.Remove(substring.IndexOf('[') - 1, 1);
                substring = substring.Remove(substring.IndexOf("]") + 1, 1);

                json = json.Remove(startIndex) + substring;
            }

            return json;
        }




        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Dictionary<string, object> StrValAndSort(Dictionary<string, object> data)
        {
            data = (Dictionary<string, object>)SortObject(data);
            foreach (var item in data)
            {
                if (data.ContainsKey(item.Key))
                {
                    if (data[item.Key] is Dictionary<string, object>)
                        data[item.Key] = StrValAndSort((Dictionary<string, object>)data[item.Key]);

                    else
                        data[item.Key] = data.First(c => c.Key == item.Key).Value.ToString() ?? "";
                }
            }
            return data;
        }



        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static object SortObject(object obj)
        {
            if (obj is Array)
                return obj;
            return ((Dictionary<string, object>)obj).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }


    }
}
