using CreativeLightProduction.Prodamus.Api.Extensions;
using CreativeLightProduction.Prodamus.Api.Interfaces;
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
    public class PaymentService : IPaymentService
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
        /// https://help.prodamus.ru/payform/integracii/tekhnicheskaya-dokumentaciya-po-avtoplatezham/formirovanie-ssylki-na-oplatu
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
        /// https://help.prodamus.ru/payform/integracii/rest-api/instrukcii-dlya-samostoyatelnaya-integracii-servisov
        /// </summary>
        /// <param name="data"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public BaseResponse<bool> Verify(VerifyRequest data)
        {
            try
            {
                var requestSign = data.Notification.GetSignature(_options.SecretKey);

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
        /// Build params http query
        /// </summary>
        /// <returns></returns>
        private string BuildQuery(CreatePaymentUrlRequest data)
        {
            var obj = JObject.FromObject(data);
            var queryString = obj.ToUrlEncodedQueryString();

            return "?" + queryString;
        }
    }
}
