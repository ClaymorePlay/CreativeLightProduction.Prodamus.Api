using CreativeLightProduction.Prodamus.Api.Models.Request;
using CreativeLightProduction.Prodamus.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Interfaces
{
    /// <summary>
    /// Payment management service 
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Create a payment url
        /// https://help.prodamus.ru/payform/integracii/tekhnicheskaya-dokumentaciya-po-avtoplatezham/formirovanie-ssylki-na-oplatu
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<CreatePaymentUrlResponse>> CreatePaymentUrl(CreatePaymentUrlRequest request);

        /// <summary>
        /// Verify payment
        /// https://help.prodamus.ru/payform/integracii/rest-api/instrukcii-dlya-samostoyatelnaya-integracii-servisov
        /// </summary>
        /// <returns></returns>
        BaseResponse<bool> Verify(VerifyRequest data);
    }
}
