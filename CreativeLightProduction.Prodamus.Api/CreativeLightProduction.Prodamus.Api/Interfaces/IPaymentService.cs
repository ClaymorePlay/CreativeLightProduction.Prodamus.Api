using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Interfaces
{
    public interface IPaymentService
    {
        Task CreatePaymentUrl();

        Task VerifyPayment();
    }
}
