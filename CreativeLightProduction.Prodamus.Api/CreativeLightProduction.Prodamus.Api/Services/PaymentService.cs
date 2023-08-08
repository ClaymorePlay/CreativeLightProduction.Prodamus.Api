using CreativeLightProduction.Prodamus.Api.Extensions;
using CreativeLightProduction.Prodamus.Api.Models.Request;
using CreativeLightProduction.Prodamus.Api.Models.Response;
using CreativeLightProduction.Prodamus.Api.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private readonly ProdamusOptions _options;

        public PaymentService(IOptions<ProdamusOptions> options)
        {
            _options = options.Value;
        }

        /// <summary>
        /// Create a payment url
        /// </summary>
        /// <returns></returns>
        public async Task<CreatePaymentUrlResponse> CreatePaymentUrl(CreatePaymentUrlRequest request)
        {
            var query = BuildQuery(request);

            var client = new HttpClient();
            var response = await client.GetAsync(_options.ServiceUrl + query);

            //if (!response.IsSuccessStatusCode)
            //    throw new Exception("Request failed");

            return new CreatePaymentUrlResponse
            {
                Result = await response.Content.ReadAsStringAsync()
            };
        }

        /// <summary>
        /// Построение параметров запроса
        /// </summary>
        /// <returns></returns>
        public string BuildQuery(CreatePaymentUrlRequest data)
        {
            var obj = JObject.FromObject(data);
            var queryString = obj.ToUrlEncodedQueryString();

            return "?" + queryString;
        }

    }
}
