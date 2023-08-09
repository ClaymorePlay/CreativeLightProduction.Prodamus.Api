using CreativeLightProduction.Prodamus.Api.Extensions;
using CreativeLightProduction.Prodamus.Api.Models.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Request
{
    public class Tax
    {
        /// <summary>
        /// // ставка НДС, с возможными значениями (при необходимоти заменить):
        ///	0 – без НДС;
        ///	1 – НДС по ставке 0%;
        ///	2 – НДС чека по ставке 10%;
        ///	3 – НДС чека по ставке 18%;
        ///	4 – НДС чека по расчетной ставке 10/110;
        ///	5 – НДС чека по расчетной ставке 18/118.
        ///	6 - НДС чека по ставке 20%;
        ///	7 - НДС чека по расчётной ставке 20/120.
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public TaxTypeEnum? tax_type { get; set; }

        /// <summary>
        /// (не обязательно) сумма налога, хх - при необходимости заменить
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(PrimitiveToStringConverter))]
        public decimal? tax_sum { get; set; }
    }
}
