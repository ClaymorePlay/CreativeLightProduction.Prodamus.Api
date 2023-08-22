using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Options
{
    /// <summary>
    /// Prodamus API service settings
    /// </summary>
    public class ProdamusOptions : HttpClientOptions
    {
        /// <summary>
        /// Service url for request
        /// </summary>
        public string ServiceUrl { get; set; } = "https://demo.payform.ru";

        /// <summary>
        /// Secret key for prodamus api
        /// https://help.prodamus.ru/payform/integracii/rest-api/url-dlya-uvedomlenii-i-sekretnyi-klyuch
        /// </summary>
        public string SecretKey { get; set; } 
    }
}
