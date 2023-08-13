using CreativeLightProduction.Prodamus.Api.Interfaces;
using CreativeLightProduction.Prodamus.Api.Options;
using CreativeLightProduction.Prodamus.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Extensions
{
    public static class StartupExtensions
    {
        /// <summary>
        /// Add prodamus services and options
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddProdamus(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProdamusOptions>(configuration.GetSection(nameof(ProdamusOptions)));

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();

            return services;
        }
    }
}
