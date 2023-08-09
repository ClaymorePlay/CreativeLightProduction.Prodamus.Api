using CreativeLightProduction.Prodamus.Api.Extensions;
using CreativeLightProduction.Prodamus.Api.Models.Request;
using CreativeLightProduction.Prodamus.Api.Models.Response;
using CreativeLightProduction.Prodamus.Api.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreativeLightProduction.Prodamus.Api.Services
{
    /// <summary>
    /// Service for the formation and confirmation of payment
    /// </summary>
    public class PaymentService
    {
        /// <summary>
        /// Prodamus options
        /// </summary>
        private readonly ProdamusOptions _options;

        public PaymentService(IOptions<ProdamusOptions> options)
        {
            _options = options.Value;
        }

        /// <summary>
        /// Create a payment url
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<CreatePaymentUrlResponse>> CreatePaymentUrl(CreatePaymentUrlRequest request)
        {
            try
            {
                var query = BuildQuery(request);

                var client = new HttpClient();
                var response = await client.GetAsync(_options.ServiceUrl + query);

                var data = Encoding.UTF8.GetString(await response.Content.ReadAsByteArrayAsync());

                return new BaseResponse<CreatePaymentUrlResponse>
                {
                    StatusCode = response.StatusCode,
                    IsSuccess = response.IsSuccessStatusCode,
                    ErrorMessage = response.IsSuccessStatusCode ? "" : data,
                    Headers = response.Headers,
                    Data = new CreatePaymentUrlResponse
                    {
                        Result = response.IsSuccessStatusCode ? data : ""
                    }
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<CreatePaymentUrlResponse>
                {
                    IsSuccess = false,
                    Trace = ex.StackTrace,
                    ErrorMessage = ex.Message,
                    Data = new CreatePaymentUrlResponse
                    {
                        Result = null
                    }
                };
            }
        }


        /// <summary>
        /// Verify payment
        /// </summary>
        /// <param name="data"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public BaseResponse<bool> Verify(VerifyRequest data)
        {
            try
            {
                var requestSign = GetSignature(data.Notification, data.Signature);

                if (String.IsNullOrWhiteSpace(requestSign))
                    throw new Exception("Signature not found");

                else if (requestSign != data.Signature)
                    throw new Exception("Signature incorrect");

                return new BaseResponse<bool>
                {
                    Data = true,
                    IsSuccess = true,
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    ErrorMessage = ex.Message,
                    Trace = ex.StackTrace
                };
            }
        }


        /// <summary>
        /// Build params http qoery
        /// </summary>
        /// <returns></returns>
        public string BuildQuery(CreatePaymentUrlRequest data)
        {
            var obj = JObject.FromObject(data);
            var queryString = obj.ToUrlEncodedQueryString();

            return "?" + queryString;
        }



        /// <summary>
        /// Получение сигнатуры
        /// </summary>
        /// <returns></returns>
        private string GetSignature(NotificationModel data, string secretKey)
        {
            var dict = GetDictionaryFromRequest(data);
            var signature = Create(dict, secretKey);

            return signature;
        }



        /// <summary>
        /// Получить ключ значение из запроса
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetDictionaryFromRequest<T>(T request)
        {
            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
            });

            var jObject = JObject.FromObject(request, new Newtonsoft.Json.JsonSerializer { NullValueHandling = NullValueHandling.Ignore });
            var date = jObject.Property("date");

            var model = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            model["products"] = JsonConvert.SerializeObject(model["products"]);

            if (date != null)
                model["date"] = date.Value.ToString();
            return model;
        }


        /// <summary>
        /// Создание сигнатуры
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="algo"></param>
        /// <returns></returns>
        private string Create(Dictionary<string, object> data, string key)
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
        /// Исправление json для формирования хэша
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private string FixJsonSignature(string json)
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
        /// Сортировка
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Dictionary<string, object> StrValAndSort(Dictionary<string, object> data)
        {
            data = (Dictionary<string, object>)SortObject(data);
            foreach (var item in data)
            {
                if (data.ContainsKey(item.Key))
                {
                    if (data[item.Key] is Dictionary<string, object>)
                        data[item.Key] = StrValAndSort((Dictionary<string, object>)data[item.Key]);

                    else
                        data[item.Key] = data[item.Key].ToString();
                }
            }
            return data;
        }



        /// <summary>
        /// Сортировка
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private object SortObject(object obj)
        {
            if (obj is Array)
                return obj;
            return ((Dictionary<string, object>)obj).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }


    }
}
