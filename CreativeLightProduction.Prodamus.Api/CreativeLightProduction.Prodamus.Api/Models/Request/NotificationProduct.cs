using CreativeLightProduction.Prodamus.Api.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class NotificationProduct
    {
        /// <summary>
        /// // id товара в системе интернет-магазина (не обязательно) - при необходимоти прописать 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? sku { get; set; }

        /// <summary>
        /// название товара - необходимо прописать название вашего товара (обязательный параметр)
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? name { get; set; }

        /// <summary>
        ///  цена за единицу товара (обязательный параметр)
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public double? price { get; set; }

        /// <summary>
        /// количество товара
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public int? quantity { get; set; }

        /// <summary>
        /// Общая сумма
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public double? sum { get; set; }

    }
}
