using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class VerifyRequest
    {
        public string Signature { get; set; }

        public NotificationModel Notification { get; set; }
    }
}
