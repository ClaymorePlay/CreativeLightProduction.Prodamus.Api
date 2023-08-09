using CreativeLightProduction.Prodamus.Api.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class NotificationModel
    {
        /// <summary>
        /// дата платежа
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// ID заказа в системе Продамус
        /// </summary>
        public string order_id { get; set; }

        /// <summary>
        /// ID заказа в системе Продамус
        /// </summary>
        public string order_num { get; set; }

        /// <summary>
        /// платежной 
        /// </summary>
        public string domain { get; set; }

        /// <summary>
        /// сумма заказа
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public double? sum { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// номер телефона клиента
        /// </summary>
        public string customer_phone { get; set; }

        /// <summary>
        /// e-mail клиента
        /// </summary>
        public string customer_email { get; set; }

        /// <summary>
        /// дополнительные данные
        /// </summary>
        public string customer_extra { get; set; }

        /// <summary>
        /// метод оплаты
        /// </summary>
        public string payment_type { get; set; }

        /// <summary>
        /// процент комиссии
        /// </summary>
        public string commission { get; set; }

        /// <summary>
        /// сумма комиссии
        /// </summary>
        public string commission_sum { get; set; }

        /// <summary>
        /// номер попытки отправки текущего уведомления
        /// </summary>
        public string attempt { get; set; }

        /// <summary>
        /// код системы интернет-магазина
        /// </summary>
        public string sys { get; set; }

        /// <summary>
        /// вк id клиента
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public long? vk_user_id { get; set; }

        /// <summary>
        /// корзина товаров
        /// </summary>
        public Product[] products { get; set; }

        /// <summary>
        /// статус оплаты
        ///        success - заказ успешно оплачен
        ///order_canceled - заявка отменена покупателем
        ///order_denied - заявка отклонена банком(отказ в рассрочке)
        /// </summary>
        public string payment_status { get; set; }

        /// <summary>
        /// расшифровка статуса оплаты
        /// </summary>
        public string payment_status_description { get; set; }
    }
}
