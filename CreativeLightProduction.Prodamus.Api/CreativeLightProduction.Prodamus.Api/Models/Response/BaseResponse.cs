using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Response
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }

        public HttpResponseHeaders? Headers { get; set; }

        public HttpStatusCode? StatusCode { get; set; }

        public bool IsSuccess { get; set; }

        public string? Trace { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
