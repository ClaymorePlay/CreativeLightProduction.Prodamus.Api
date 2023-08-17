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

        [TestMethod]
        public async Task SetActivity()
        {
            var service = GetService();

            var response = await service.SetActivity(new Models.Request.SetActivityRequest
            {
                Subscription = 1,
                VkUserId = 123,
                ActiveManager = false
            });
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