using CreativeLightProduction.Prodamus.Api.Extensions;
using CreativeLightProduction.Prodamus.Api.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class SetSubscriptionPaymentDateRequest : ISignatureModel
    {
        /// <summary>
        /// Client identification type. Possible values:
        /// profile – profile id in the Prodamus system
        /// vk_user_id - VK profile id
        /// customer_phone - customer phone number
        /// </summary>
        [JsonProperty("auth_type")]
        public string? AuthType { get; set; }

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
        /// Client profile ID in the Prodamus system. 
        /// Required if auth_type = profile
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        [JsonProperty("profile")]
        public int? Profile { get; set; }

        /// <summary>
        /// VKontakte client profile ID. 
        /// Required if auth_type parameter value = vk_user_id
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        [JsonProperty("vk_user_id")]
        public int? VkUserId { get; set; }

        /// <summary>
        /// Customer phone number in the format: +79999999999/
        /// Required if auth_type parameter value = customer_phone
        /// </summary>
        [JsonProperty("customer_phone")]
        public string? CustomerPhone { get; set; }

        /// <summary>
        /// Set date for next payment
        /// date in the format: yyyy-mm-dd hh:mm
        /// the date cannot be in the past or earlier than the settlement date of the next payment
        /// </summary>
        [JsonProperty("date")]
        public string? Date { get; set; } 
    }
}
