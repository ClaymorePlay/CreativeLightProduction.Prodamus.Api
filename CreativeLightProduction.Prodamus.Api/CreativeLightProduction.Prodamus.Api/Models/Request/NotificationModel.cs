using CreativeLightProduction.Prodamus.Api.Extensions;
using CreativeLightProduction.Prodamus.Api.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class NotificationModel : ISignatureModel
    {
        /// <summary>
        /// дата платежа
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? date { get; set; }

        /// <summary>
        /// ID заказа в системе Продамус
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? order_id { get; set; }

        /// <summary>
        /// ID заказа в системе Продамус
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? order_num { get; set; }

        /// <summary>
        /// платежной 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? domain { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? payment_init { get; set; }

        /// <summary>
        /// сумма заказа
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public double? sum { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? currency { get; set; }

        /// <summary>
        /// номер телефона клиента
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? customer_phone { get; set; }

        /// <summary>
        /// e-mail клиента
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? customer_email { get; set; }

        /// <summary>
        /// дополнительные данные
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? customer_extra { get; set; }

        /// <summary>
        /// метод оплаты
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? payment_type { get; set; }

        /// <summary>
        /// процент комиссии
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? commission { get; set; }

        /// <summary>
        /// сумма комиссии
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? commission_sum { get; set; }

        /// <summary>
        /// номер попытки отправки текущего уведомления
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? attempt { get; set; }

        /// <summary>
        /// код системы интернет-магазина
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? sys { get; set; }

        /// <summary>
        /// вк id клиента
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public long? vk_user_id { get; set; }

        /// <summary>
        /// корзина товаров
        /// </summary>
        public NotificationProduct[]? products { get; set; }

        /// <summary>
        /// статус оплаты
        ///        success - заказ успешно оплачен
        ///order_canceled - заявка отменена покупателем
        ///order_denied - заявка отклонена банком(отказ в рассрочке)
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? payment_status { get; set; }

        /// <summary>
        /// расшифровка статуса оплаты
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? payment_status_description { get; set; }
    }
}
