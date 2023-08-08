using CreativeLightProduction.Prodamus.Api.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class CreatePaymentUrlRequest
    {
        /// <summary>
        /// Идентификатор заказа
        /// Обязательный
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        ///  ИМЯ@prodamus.ru - e-mail адрес клиента
        /// </summary>
        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Телефон клиента
        /// </summary>
        [JsonProperty("customer_phone")]
        public string CustomerPhone { get; set; }

        /// <summary>
        /// Перечень товаров заказа
        /// </summary>
        [JsonProperty("products")]
        public Product[] Products { get; set; }

        /// <summary>
        /// id подписки (при необходимости прописать)
        /// актуально и обязательно только для рекуррентных платежей, передается вместо параметра products
        /// </summary>
        [JsonProperty("subscription")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public int? Subscription { get; set; }

        /// <summary>
        /// Валюта платежа. Возможные значения:
        ///rub
        ///usd
        ///eur
        ///kzt
        ///P.S.Параметр должен быть в нижнем регистре.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }


        /// <summary>
        /// Сигнатура
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// идентификатор партнера (ПРОМОКОД)
        /// </summary>
        [JsonProperty("ref")]
        public string Ref { get; set; }

        /// <summary>
        /// Вк id пользователя
        /// </summary>
        [JsonProperty("vk_user_id")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public long? VkUserId { get; set; }

        /// <summary>
        /// фио пользователя в ВК (при необходимости прописать)
        /// </summary>
        [JsonProperty("vk_user_name")]
        public string VkUserName { get; set; }

        /// <summary>
        /// дополнительные данные
        /// </summary>
        [JsonProperty("customer_extra")]
        public string CustomerExtra { get; set; }

        /// <summary>
        /// Лимит автовыплат
        /// </summary>
        [JsonProperty("subscription_limit_autopayments")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public int? SubscriptionLimitAutopayments { get; set; }

        /// <summary>
        /// для интернет-магазинов доступно только действие "Оплата"
        /// "link" - возвращает ссылку, которую отправляем пользователю для самостоятельного перехода на страницу оплаты
        ///"pay" - отправляет покупателя сразу на оплату.Используется для интернет-магазинов действие "Оплата" 
        /// </summary>
        [JsonProperty("do")]
        public string Do { get; set; }

        /// <summary>
		/// url-адрес для возврата пользователя без оплаты (при необходимости прописать свой адрес) 
		/// </summary>
        [JsonProperty("urlReturn")]
        public string UrlReturn { get; set; }

        /// <summary>
        /// url-адрес для возврата пользователя при успешной оплате 
        /// (при необходимости прописать свой адрес)
        /// </summary>
        [JsonProperty("urlSuccess")]
        public string UrlSuccess { get; set; }

        /// <summary>
        /// служебный url-адрес для уведомления интернет-магазина 
        ///	о поступлении оплаты по заказу
        /// пока реализован только для Advantshop, 
        /// формат данных настроен под систему интернет-магазина
        /// (при необходимости прописать свой адрес)
        /// </summary>
        [JsonProperty("urlNotification")]
        public string UrlNotification { get; set; }

        /// <summary>
        /// код системы интернет-магазина, запросить у поддержки, 
        /// для самописных систем можно оставлять пустым полем
        /// (при необходимости прописать свой код)
        /// </summary>
        [JsonProperty("sys")]
        public string Sys { get; set; }

        /// <summary>
        /// Параметр для проверки негативного сценария с отказом по рассрочке. ❗Работает только в демо-режиме❗ Доступное значение: reject
        /// </summary>
        [JsonProperty("demoFlow")]
        public string DemoFlow { get; set; }

        /// <summary>
        /// Если  передано значение 1, то платеж пройдет в демо-режиме
        /// </summary>
        [JsonProperty("demo_mode")]
        public string DemoMode { get; set; }



        /// <summary>
        /// отключение рассрочки если передан и не 0, методы оплаты связанные с рассрочкой будут недоступны для выбора при оплате
        /// </summary>
        [JsonProperty("installments_disabled")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public int? InstallmentsDisabled { get; set; }

        /// <summary>
        /// метод оплаты, выбранный клиентом
        /// если есть возможность выбора на стороне интернет-магазина,
        /// иначе клиент выбирает метод оплаты на стороне платежной формы
        /// варианты (при необходимости прописать значение):
        /// 	AC - банковская карта
        /// 	PC - Яндекс.Деньги
        /// 	QW - Qiwi Wallet
        /// 	WM - Webmoney
        /// 	GP - платежный терминал
        /// </summary>
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// сумма скидки на заказ
        /// указывается только в том случае, если скидка 
        /// не прменена к товарным позициям на стороне интернет-магазина
        /// алгоритм распределения скидки по товарам 
        /// настраивается на стороне пейформы
        /// </summary>
        [JsonProperty("discount_value")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public double? DiscountValue { get; set; }

        /// <summary>
        /// Сумма заказа
        /// </summary>
        [JsonProperty("order_sum")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public decimal? OrderSum { get; set; }

        /// <summary>
        /// тип плательщика, с возможными значениями:
        ///     FROM_INDIVIDUAL - Физическое лицо
        ///     FROM_LEGAL_ENTITY - Юридическое лицо
        ///     FROM_FOREIGN_AGENCY - Иностранная организация
        ///     (не обязательно. если форма работает в режиме самозанятого 
        /// значение по умолчанию: FROM_INDIVIDUAL)
        /// </summary>
        [JsonProperty("npd_income_type")]
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public long? NpdIncomeType { get; set; }

        /// <summary>
        /// Если передано значение json, то веб-хуки от Продамуса будут приходить в формате json
        /// </summary>
        [JsonProperty("callbackType")]
        public string CallbackType { get; set; }

        /// <summary>
        /// инн плательщика (при необходимости прописат)
        ///     (обязательно, если форма в режиме самозанятого 
        ///      и тип плательщика FROM_LEGAL_ENTITY)
        /// </summary>
        [JsonProperty("npd_income_inn")]
        public string NpdIncomeInn { get; set; }

        /// <summary>
        /// Лимит оплат по сформированной ссылке
        /// </summary>
        [JsonProperty("payments_limit")]
        public string PaymentsLimit { get; set; }

        /// <summary>
        /// Эквайринг.
        ///Возможные значения:
        ///sbrf
        ///moneta
        ///qiwi
        ///xpay
        ///xpaykz
        /// </summary>
        [JsonProperty("acquiring")]
        public string Acquiring { get; set; }

        /// <summary>
        /// название компании плательщика (при необходимости прописать название)
        ///          (обязательно, если форма в режиме самозанятого 
        ///           и тип плательщика FROM_LEGAL_ENTITY или FROM_FOREIGN_AGENCY)
        /// </summary>
        [JsonProperty("npd_income_company")]
        public string NpdIncomeCompany { get; set; }

        /// <summary>
        /// срок действия ссылки в формате: дд.мм.гггг чч:мм или гггг-мм-дд чч:мм
        ///      при необходимости добавить дату
        ///      (не обязательно, по умолчанию срок действия ссылки не ограничен)
        /// </summary>
        [JsonProperty("link_expired")]
        public string LinkExpired { get; set; }

        /// <summary>
        /// дата начала подписки в формате: дд.мм.гггг чч:мм или гггг-мм-дд чч:мм
        ///      при необходимости добавить дату
        ///      (не обязательно, актуально только для рекуррентных платежей, 
        ///       по умолчанию текущая дата/время)
        /// </summary>
        [JsonProperty("subscription_date_start")]
        public string SubscriptionDateStart { get; set; }

        /// <summary>
        /// текст который будет показан пользователю после совершения оплаты
	    ///       (не обязательно)
        /// </summary>
        [JsonProperty("paid_content")]
        public string PaidContent { get; set; }



    }
}
