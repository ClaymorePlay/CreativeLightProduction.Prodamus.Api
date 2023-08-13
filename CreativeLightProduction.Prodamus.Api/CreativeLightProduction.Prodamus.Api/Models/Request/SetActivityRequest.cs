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
    public class SetActivityRequest : ISignatureModel
    {
        [JsonProperty("signature")]
        public string? Signature { get; set; }

        [JsonProperty("subscription")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public int? Subscription { get; set; }

        [JsonProperty("tg_user_id")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public int? TgUserId { get; set; }

        [JsonProperty("customer_email")]
        public string? CustomerEmail { get; set; }

        [JsonProperty("profile")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public int? Profile { get; set; }

        [JsonProperty("vk_user_id")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public int? VkUserId { get; set; }

        [JsonProperty("customer_phone")]
        public string? CustomerPhone { get; set; }

        [JsonProperty("active_manager")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public bool? ActiveManager { get; set; }

        [JsonProperty("active_user")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public bool? ActiveUser { get; set; }
    }
}
