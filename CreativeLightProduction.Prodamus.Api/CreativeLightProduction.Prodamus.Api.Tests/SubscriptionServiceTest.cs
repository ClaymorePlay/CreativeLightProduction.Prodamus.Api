using CreativeLightProduction.Prodamus.Api.Interfaces;
using CreativeLightProduction.Prodamus.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Tests
{
    [TestClass]
    public class SubscriptionServiceTest
    {

        private readonly string _secretKey = "2y2aw4oknnke80bp1a8fniwuuq7tdkwmmuq7vwi4nzbr8z1182ftbn6p8mhw3bhz";
        private readonly string _baseUrl = "https://demo.payform.ru";

        /// <summary>
        /// Testing set activity method
        /// </summary>
        /// <param name="vk_user_id"></param>
        /// <param name="subscription"></param>
        /// <param name="activeManager"></param>
        /// <param name="activeUser"></param>
        /// <returns></returns>
        [TestMethod]
        [DataRow(123, 1, false, null)]
        public async Task SetActivity(int? vk_user_id, int? subscription, bool? activeManager, bool? activeUser)
        {
            var service = GetService();

            var response = await service.SetActivity(new Models.Request.SetActivityRequest
            {
                Subscription = subscription,
                VkUserId = vk_user_id,
                ActiveManager = activeManager,
                ActiveUser = activeUser
            });

            Assert.IsNotNull(response?.Data);
            Assert.IsTrue(response.Data && response.IsSuccess);
        }


        /// <summary>
        /// Testing set subscription discount
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="customer_phone"></param>
        /// <param name="discount_value"></param>
        /// <returns></returns>
        [TestMethod]
        [DataRow(1, "+79999999999", 1000)]
        public async Task SetSubscriptionDiscount(int? subscription, string? customer_phone, int? discount_value)
        {
            var service = GetService();

            var response = await service.SetSubscriptionDiscount(new Models.Request.SetSubscriptionDiscountRequest
            {
                Subscription = subscription,
                CustomerPhone = customer_phone,
                DiscountValue = discount_value
            });

            Assert.IsNotNull(response?.Data);
            Assert.IsTrue(response.Data && response.IsSuccess);
        }

        /// <summary>
        /// Testing set subscription discount
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="customer_phone"></param>
        /// <param name="discount_value"></param>
        /// <returns></returns>
        [TestMethod]
        [DataRow(1, "vk_user_id", 123, "2021-12-31 23:59")]
        public async Task SetSubscriptionPaymentDate(int? subscription, string? auth_type, int? vk_user_id, string? date)
        {
            var service = GetService();

            var response = await service.SetSubscriptionPaymentDate(new Models.Request.SetSubscriptionPaymentDateRequest
            {
                Subscription = subscription,
                AuthType = auth_type,
                Date = date,
                VkUserId = vk_user_id
            });

            Assert.IsNotNull(response?.Data);
            Assert.IsTrue(response.Data && response.IsSuccess);
        }


        /// <summary>
        /// Получение сервиса
        /// </summary>
        /// <returns></returns>
        private ISubscriptionService GetService()
        {
            var service = new SubscriptionService(Microsoft.Extensions.Options.Options.Create(new Api.Options.ProdamusOptions
            {
                SecretKey = _secretKey,
                ServiceUrl = _baseUrl
            }));

            return service;
        }
    }
}