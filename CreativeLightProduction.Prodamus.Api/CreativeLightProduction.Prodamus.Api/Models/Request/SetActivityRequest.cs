using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class SetActivityRequest
    {
        [JsonProperty("signature")]
        public string? Signature { get; set; }

        [JsonProperty("subscription")]
        public int? Subscription { get; set; }

        [JsonProperty("tg_user_id")]
        public int? TgUserId { get; set; }

        [JsonProperty("customer_email")]
        public string? CustomerEmail { get; set; }

        [JsonProperty("profile")]
        public int? Profile { get; set; }

        [JsonProperty("vk_user_id")]
        public int? VkUserId { get; set; }

        [JsonProperty("customer_phone")]
        public string? CustomerPhone { get; set; }

        [JsonProperty("active_manager")]
        public bool? ActiveManager { get; set; }

        [JsonProperty("active_user")]
        public bool? ActiveUser { get; set; }
    }
}
