using CreativeLightProduction.Prodamus.Api.Interfaces;
using CreativeLightProduction.Prodamus.Api.Models.Request;
using CreativeLightProduction.Prodamus.Api.Options;
using CreativeLightProduction.Prodamus.Api.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Tests
{
    [TestClass]
    public class PaymentServiceTest
    {

        private readonly string _secretKey = "2y2aw4oknnke80bp1a8fniwuuq7tdkwmmuq7vwi4nzbr8z1182ftbn6p8mhw3bhz";
        private readonly string _baseUrl = "https://demo.payform.ru";

        /// <summary>
        /// Get payment url test
        /// </summary>
        /// <param name="doType"></param>
        /// <param name="orderId"></param>
        /// <param name="customerPhone"></param>
        /// <param name="customerExtra"></param>
        /// <param name="productName"></param>
        /// <param name="productPrice"></param>
        [TestMethod]
        [DataRow("link", "test2", "79998887755", "Полная оплата курса", "Обучающие материалы", "10000")]
        [DataRow("link", "test3", "79998887755", "Full payment", "Materials", "10000")]
        public void PaymentInitTest(string doType, string orderId, string customerPhone, string customerExtra, string productName, string productPrice)
        {
            var service = GetService();

            var data = new CreatePaymentUrlRequest
            {
                OrderId = orderId,
                CustomerPhone = customerPhone,
                CustomerExtra = customerExtra,
                Do = doType,
                Products = new System.Collections.Generic.List<Product>
                {
                    new Product
                    {
                        Name = productName,
                        Price = Convert.ToDouble(productPrice),
                        Quantity = 1,
                        Sum = Convert.ToDouble(productPrice) * 1,
                    }
                }.ToArray()
            };

            var response = service.CreatePaymentUrl(data).Result;

            Assert.IsTrue(response.IsSuccess && !string.IsNullOrWhiteSpace(response.Data?.Result) && string.IsNullOrWhiteSpace(response.ErrorMessage));
            Console.WriteLine(response.Data);
        }

        /// <summary>
        /// Payment verify test
        /// </summary>
        [TestMethod]
        [DataRow("7bc9510a64e3e31e730b865866b5d15c7603482e610b13b5cbeef779cda443a4", "2023-08-02T00:00:00+03:00", "1", "test", "edvibe.payform.ru",
            1000.00, "+79999999999", "email@domain.com", "тест", "Plastic card Visa, MasterCard, MIR", "3.5", "35.00", "1", "test",
            "success", "Successful payment", "Access to educational materials", 1000.00, 1, 1000.00, null, null)]

        [DataRow("d404d1fd1a7afa0a2e1cf14b703abe3f67935fe800995fd0e458f8b190773ba8", "2023-08-02T00:00:00+01:00", "1", "modal", "edvibe.payform.ru",
            1000.00, "+79999999999", "email@domain.com", "тест", "Plastic card Visa, MasterCard, MIR", "3.5", "35.00", "1", "test",
            "success", "Successful payment2", "Access to reports", 1000.00, 1, 1000.00, null, null)]

        [DataRow("3f388d28b6ff09b25cdac28a5a6c66d8d9b7ebd59522a91fe64334e01dc7c6cf", "2023-08-09T17:52:09+03:00", "14817691", "1013", "edvibe.payform.ru",
            150.00, "", "xcxcxcasdasd@mail.ru", "", "Payment by card issued in the Russian Federation", "3.5", "5.25", "1", null,
            "success", "Successful payment", "Buying a marathon", 150.00, 1, 150.00, "manual", "rub")]

        [DataRow("24cfff42a3242269abae676153fe573d153980005328a462819ec9c0709f39ff", "2023-08-09T00:00:00+03:00", "1", "test", "edvibe.payform.ru",
            1000.00, "+79999999999", "email@domain.com", "test", "Plastic card Visa, MasterCard, MIR", "3.5", "35.00", "1", "test",
            "success", "Successful payment", "Access to educational materials", 1000.00, 1, 1000.00, null, null)]
        public void VarifyPaymentTest(string signature, string date, string orderId, string orderNum,
            string domain, double sum, string customerPhone, string customerEmail, string customerExtra, string paymentType,
            string commission, string commissionSum, string attempt, string sys, string paymentStatus, string paymentDesc,
            string productName, double productPrice, int productQuantity, double productSum, string paymentInit, string currency)
        {
            var service = GetService();

            var request = new VerifyRequest
            {
                Notification = new NotificationModel()
                {
                    date = date,
                    order_id = orderId,
                    order_num = orderNum,
                    domain = domain,
                    sum = sum,
                    customer_phone = customerPhone,
                    customer_email = customerEmail,
                    customer_extra = customerExtra,
                    payment_type = paymentType,
                    commission = commission,
                    commission_sum = commissionSum,
                    attempt = attempt,
                    currency = currency,
                    payment_init = paymentInit,
                    sys = sys,
                    payment_status = paymentStatus,
                    payment_status_description = paymentDesc,
                    products = new List<NotificationProduct>
                {
                    new NotificationProduct
                    {
                        name = productName,
                        price = productPrice,
                        quantity = productQuantity,
                        sum = productSum
                    }
                }.ToArray()
                },
                Signature = signature
            };


            var response = service.Verify(request);

            Console.WriteLine(response.Data);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccess && String.IsNullOrWhiteSpace(response.ErrorMessage) && response.Data);
        }


        /// <summary>
        /// Получение сервиса
        /// </summary>
        /// <returns></returns>
        private IPaymentService GetService()
        {
            var service = new PaymentService(Microsoft.Extensions.Options.Options.Create(new Api.Options.ProdamusOptions
            {
                SecretKey = _secretKey,
                ServiceUrl = _baseUrl
            }));

            return service;
        }

    }
}
