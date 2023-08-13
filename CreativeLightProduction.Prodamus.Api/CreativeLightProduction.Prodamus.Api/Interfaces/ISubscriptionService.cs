using CreativeLightProduction.Prodamus.Api.Models.Request;
using CreativeLightProduction.Prodamus.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Interfaces
{
    public interface ISubscriptionService
    {
        /// <summary>
        /// This method is used to manage the statuses (activation/deactivation) of the subscription
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse<bool>> SetActivity(SetActivityRequest request);

        /// <summary>
        /// This method is used to manage the subscription discount
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<bool>> SetSubscriptionDiscount(SetSubscriptionDiscountRequest request);

        /// <summary>
        /// Using this method, you can shift the date of the next subscription payment. 
        /// You can only shift the date "into the future" relative to the current set date for the next payment. 
        /// Thus increasing the length of stay in the club.
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<bool>> SetSubscriptionPaymentDate(SetSubscriptionPaymentDateRequest request);
    }
}
