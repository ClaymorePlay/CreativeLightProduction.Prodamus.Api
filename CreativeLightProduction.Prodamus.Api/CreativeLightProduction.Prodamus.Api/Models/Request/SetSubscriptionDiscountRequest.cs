using CreativeLightProduction.Prodamus.Api.Extensions;
using CreativeLightProduction.Prodamus.Api.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class SetSubscriptionDiscountRequest : ISignatureModel
    {
        /// <summary>
        /// Request signature
        /// </summary>
        [JsonProperty("signature")]
        public string? Signature { get; set; }

        /// <summary>
        /// Subscription ID
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        [JsonProperty("subscription")]
        public int? Subscription { get; set; }

        /// <summary>
        /// Amount of discount
        /// decimal number up to two decimal places
        /// the value must be greater than zero and not exceed the base cost of the subscription
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        [JsonProperty("discount_value")]
        public double? DiscountValue { get; set; }

        /// <summary>
        /// The number of payments for which the discount will apply
        /// default: 0 (number of discounted payments is not limited)
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        [JsonProperty("num")]
        public int? Num { get; set; }

        /// <summary>
        /// Client Profile ID
        /// required if one of the parameters vk_user_id/tg_user_id/customer_phone/customer_emai is not passed
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        [JsonProperty("profile")]
        public int? Profile { get; set; }

        /// <summary>
        /// Client Profile ID VKontakte
        /// required if one of the profile/tg_user_id/customer_phone/customer_email parameters is not passed
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        [JsonProperty("vk_user_id")]
        public int? VkUserId { get; set; }

        /// <summary>
        /// Telegram client profile ID
        /// required if one of the vk_user_id/profile/customer_phone/customer_email parameters is not passed
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        [JsonProperty("tg_user_id")]
        public int? TgUserId { get; set; }

        /// <summary>
        /// Customer phone number in the format: +79999999999
        /// required if profile and vk_user_id are not passed
        /// </summary>
        [JsonProperty("customer_phone")]
        public string? CustomerPhone { get; set; }

        /// <summary>
        /// Client Email
        /// required if one of the vk_user_id/tg_user_id/customer_phone/profile parameters is not passed
        /// </summary>
        [JsonProperty("customer_email")]
        public string? CustomerEmail { get; set; }
    }
}
