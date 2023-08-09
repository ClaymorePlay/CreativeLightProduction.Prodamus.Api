using CreativeLightProduction.Prodamus.Api.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class Product
    {
        /// <summary>
        /// // id товара в системе интернет-магазина (не обязательно) - при необходимоти прописать 
        /// </summary>
        public string sku { get; set; }

        /// <summary>
        /// название товара - необходимо прописать название вашего товара (обязательный параметр)
        /// </summary>
        public string name { get; set; }

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
        /// данные о налоге
        /// (не обязательно, если не указано будет взято из настроек Магазина на стороне системы)
        /// </summary>
        public Tax? tax { get; set; }

        /// <summary>
        /// Тип оплаты, с возможными значениями (при необходимости заменить):
        ///	1 - полная предварительная оплата до момента передачи предмета расчёта;
        ///	2 - частичная предварительная оплата до момента передачи 
        ///      предмета расчёта;
        ///	3 - аванс;
        ///	4 - полная оплата в момент передачи предмета расчёта;
        ///	5 - частичная оплата предмета расчёта в момент его передачи с последующей оплатой в кредит;
        ///	6 - передача предмета расчёта без его оплаты в момент его передачи с последующей оплатой в кредит;
        ///	7 - оплата предмета расчёта после его передачи с оплатой в кредит. (не обязательно, если не указано будет взято из настроек Магазина на стороне системы)
        /// </summary>
        public string paymentMethod { get; set; }

        /// <summary>
        /// Общая сумма
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public double? sum { get; set; }

        /// <summary>
        /// Тип оплачиваемой позиции, с возможными значениями (при необходимости заменить):
        ///	1 - товар;
        ///	2 - подакцизный товар;
        ///	3 - работа;
        ///	4 - услуга;
        ///	5 - ставка азартной игры;
        ///	6 - выигрыш азартной игры;
        ///	7 - лотерейный билет;
        ///	8 - выигрыш лотереи;
        ///	9 - предоставление РИД;
        ///	10 - платёж;
        ///	11 - агентское вознаграждение;
        ///	12 - составной предмет расчёта;
        ///	13 - иной предмет расчёта. (не обязательно, если не указано будет взято из настроек Магазина на стороне системы)
        /// </summary>
        public string paymentObject { get; set; }
    }
}
