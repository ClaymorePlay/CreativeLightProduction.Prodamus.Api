using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Options
{
    public class HttpClientOptions
    {
        /// <summary>
        /// Request timeout
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Content buffer size
        /// </summary>
        public int? MaxResponseContentBufferSize { get; set; }
    }
}
