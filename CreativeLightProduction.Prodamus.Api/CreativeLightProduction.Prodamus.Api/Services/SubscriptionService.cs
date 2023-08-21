using CreativeLightProduction.Prodamus.Api.Extensions;
using CreativeLightProduction.Prodamus.Api.Interfaces;
using CreativeLightProduction.Prodamus.Api.Models.Consts;
using CreativeLightProduction.Prodamus.Api.Models.Request;
using CreativeLightProduction.Prodamus.Api.Models.Response;
using CreativeLightProduction.Prodamus.Api.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        /// <summary>
        /// Prodamus options
        /// </summary>
        private readonly ProdamusOptions _options;

        public SubscriptionService(IOptions<ProdamusOptions> options)
        {
            _options = options.Value;
        }

        /// <summary>
        /// This method is used to manage the statuses (activation/deactivation) of the subscription
        /// https://help.prodamus.ru/payform/integracii/rest-api-1/setactivity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> SetActivity(SetActivityRequest request)
        {
            try
            {
                var signature = request.GetSignature(_options.SecretKey);
                request.Signature = signature;

                var dict = BaseExtensions.GetDictionaryFromRequest(request);
                string url = _options.ServiceUrl + RequestConsts.SetActivityUri;

                using (var client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(dict.ToDictionary(k => k.Key, v => v.Value.ToString()));

                    var response = await client.PostAsync(url, content);
                    var error = Encoding.UTF8.GetString(await response.Content.ReadAsByteArrayAsync());

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(error);
                

                    return new BaseResponse<bool>
                    {
                        StatusCode = HttpStatusCode.OK,
                        IsSuccess = true,
                        Data = true,
                        Headers = response.Headers
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message,
                    Trace = ex.StackTrace,
                    Data = false
                };
            }
        }

        /// <summary>
        /// This method is used to manage the subscription discount
        /// https://help.prodamus.ru/payform/integracii/rest-api-1/setsubscriptiondiscount
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> SetSubscriptionDiscount(SetSubscriptionDiscountRequest request)
        {
            try
            {
                var signature = request.GetSignature(_options.SecretKey);
                request.Signature = signature;

                var content = new FormUrlEncodedContent(ToDictionary(request));

                using var client = new HttpClient();
                var response = await client.PostAsync(_options.ServiceUrl + RequestConsts.SetSubscriptionDiscountUri, content);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(Encoding.UTF8.GetString(await response.Content.ReadAsByteArrayAsync()));

                return new BaseResponse<bool>
                {
                    StatusCode = response.StatusCode,
                    IsSuccess = response.IsSuccessStatusCode,
                    Data = response.IsSuccessStatusCode,
                    Headers = response.Headers
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message,
                    Trace = ex.StackTrace,
                    Data = false
                };
            }
        }


        /// <summary>
        /// Using this method, you can shift the date of the next subscription payment. 
        /// You can only shift the date "into the future" relative to the current set date for the next payment. 
        /// Thus increasing the length of stay in the club.
        /// https://help.prodamus.ru/payform/integracii/rest-api-1/setsubscriptionpaymentdate
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> SetSubscriptionPaymentDate(SetSubscriptionPaymentDateRequest request)
        {
            try
            {
                var signature = request.GetSignature(_options.SecretKey);
                request.Signature = signature;

                var content = new FormUrlEncodedContent(ToDictionary(request));

                var client = new HttpClient();
                var response = await client.PostAsync(_options.ServiceUrl + RequestConsts.SetSubscriptionPaymentDate, content);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(Encoding.UTF8.GetString(await response.Content.ReadAsByteArrayAsync()));


                return new BaseResponse<bool>
                {
                    StatusCode = response.StatusCode,
                    IsSuccess = response.IsSuccessStatusCode,
                    Data = response.IsSuccessStatusCode,
                    Headers = response.Headers
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message,
                    Trace = ex.StackTrace,
                    Data = false
                };
            }
        }


        private static Dictionary<string, string> ToDictionary(object obj)
        {
            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings { Formatting = Formatting.None, NullValueHandling = NullValueHandling.Ignore });
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            foreach(var value in dictionary)
            {
                dictionary[value.Key] = value.Value.ToString().Replace("\"", "");
            };

            return dictionary;
        }
    }
}
