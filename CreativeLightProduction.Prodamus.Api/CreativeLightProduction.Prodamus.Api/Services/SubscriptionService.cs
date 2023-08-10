using CreativeLightProduction.Prodamus.Api.Models.Request;
using CreativeLightProduction.Prodamus.Api.Models.Response;
using CreativeLightProduction.Prodamus.Api.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Services
{
    public class SubscriptionService
    {
        /// <summary>
        /// Prodamus options
        /// </summary>
        private readonly ProdamusOptions _options;

        public SubscriptionService(IOptions<ProdamusOptions> options)
        {
            _options = options.Value;
        }

        public async Task<BaseResponse<bool>> SetActivity(SetActivityRequest request)
        {
            var client = new HttpClient();
            ////var response = await client.PostAsync(_options.ServiceUrl);

            return new BaseResponse<bool>();
        }

    }
}
