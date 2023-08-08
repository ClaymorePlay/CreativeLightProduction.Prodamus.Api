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
        [TestMethod]
        //[DataRow()]
        public async Task CreatePaymentUrl()
        {
            try
            {
                var options = new ProdamusOptions()
                {
                    ServiceUrl = "https://demo.payform.ru",
                    SecretKey = "2y2aw4oknnke80bp1a8fniwuuq7tdkwmmuq7vwi4nzbr8z1182ftbn6p8mhw3bhz"
                };
                var service = new PaymentService(Microsoft.Extensions.Options.Options.Create(options));

                var url = await service.CreatePaymentUrl(new Models.Request.CreatePaymentUrlRequest
                {
                    Do = "link",
                    OrderId = "PRODUCT1",
                    CustomerEmail = "test@mail.ru",
                    CustomerPhone = "+37377997738",
                    CustomerExtra = "TEST DESC",
                    Products = new List<Models.Request.Product>
                {
                    new Product
                    {
                        Name = "Product555",
                        Price = 200,
                        Quantity = 5
                    }
                }.ToArray()
                });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
