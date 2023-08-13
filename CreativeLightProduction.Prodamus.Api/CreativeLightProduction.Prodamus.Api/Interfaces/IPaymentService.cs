using CreativeLightProduction.Prodamus.Api.Models.Request;
using CreativeLightProduction.Prodamus.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        /// Create a payment url
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<CreatePaymentUrlResponse>> CreatePaymentUrl(CreatePaymentUrlRequest request);

        /// <summary>
        /// Verify payment
        /// </summary>
        /// <returns></returns>
        BaseResponse<bool> Verify(VerifyRequest data);
    }
}
