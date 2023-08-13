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
using System.Linq;
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
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> SetActivity(SetActivityRequest request)
        {
            try
            {
                var signature = request.GetSignature(_options.SecretKey);
                request.Signature = signature;

                var content = new FormUrlEncodedContent(ToDictionary<string>(request));

                var client = new HttpClient();
                var response = await client.PostAsync(_options.ServiceUrl + RequestConsts.SetActivityUri, content);

                return new BaseResponse<bool>
                {
                    StatusCode = response.StatusCode,
                    IsSuccess = response.IsSuccessStatusCode,
                    Data = true,
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
        /// This method is used to manage the subscription discount
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> SetSubscriptionDiscount(SetSubscriptionDiscountRequest request)
        {
            try
            {
                var signature = request.GetSignature(_options.SecretKey);
                request.Signature = signature;

                var content = new FormUrlEncodedContent(ToDictionary<string>(request));

                var client = new HttpClient();
                var response = await client.PostAsync(_options.ServiceUrl + RequestConsts.SetSubscriptionDiscountUri, content);

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
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> SetSubscriptionPaymentDate(SetSubscriptionPaymentDateRequest request)
        {
            try
            {
                var signature = request.GetSignature(_options.SecretKey);
                request.Signature = signature;

                var content = new FormUrlEncodedContent(ToDictionary<string>(request));

                var client = new HttpClient();
                var response = await client.PostAsync(_options.ServiceUrl + RequestConsts.SetSubscriptionPaymentDate, content);

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


        private static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
            return dictionary;
        }
    }
}
