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
    /// Subscription management service
    /// </summary>
    public interface ISubscriptionService
    {
        /// <summary>
        /// This method is used to manage the statuses (activation/deactivation) of the subscription
        /// https://help.prodamus.ru/payform/integracii/rest-api-1/setactivity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse<bool>> SetActivity(SetActivityRequest request);

        /// <summary>
        /// This method is used to manage the subscription discount
        /// https://help.prodamus.ru/payform/integracii/rest-api-1/setsubscriptiondiscount
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<bool>> SetSubscriptionDiscount(SetSubscriptionDiscountRequest request);

        /// <summary>
        /// Using this method, you can shift the date of the next subscription payment. 
        /// You can only shift the date "into the future" relative to the current set date for the next payment. 
        /// Thus increasing the length of stay in the club.
        /// https://help.prodamus.ru/payform/integracii/rest-api-1/setsubscriptionpaymentdate
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<bool>> SetSubscriptionPaymentDate(SetSubscriptionPaymentDateRequest request);
    }
}
