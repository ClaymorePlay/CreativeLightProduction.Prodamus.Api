using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Consts
{
    public class RequestConsts
    {
        /// <summary>
        /// URL to the request to manage the subscription discount
        /// </summary>
        public const string SetSubscriptionDiscountUri = "/rest/setSubscriptionDiscount/";

        /// <summary>
        /// url to request to set the status management (activation/deactivation) of the subscription
        /// </summary>
        public const string SetActivityUri = "/rest/setActivity/";

        /// <summary>
        /// url to request to set the next payment date
        /// </summary>
        public const string SetSubscriptionPaymentDate = "/rest/setSubscriptionPaymentDate/";
    }
}
