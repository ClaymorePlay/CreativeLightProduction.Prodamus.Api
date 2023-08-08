using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Models.Enum
{
    public enum TaxTypeEnum
    {
        /// <summary>
        /// без НДС
        /// </summary>
        WithoutVat = 0,

        /// <summary>
        ///НДС по ставке 0%
        /// </summary>
        VatZeroPercent = 1,

        /// <summary>
        /// НДС чека по ставке 10%
        /// </summary>
        VatTenPercent = 2,

        /// <summary>
        /// НДС чека по ставке 18%
        /// </summary>
        VatEighteenPersent = 3,

        /// <summary>
        /// НДС чека по расчетной ставке 10/110
        /// </summary>
        VatTenAndHundredTenPersent = 4,

        /// <summary>
        /// НДС чека по расчетной ставке 18/118
        /// </summary>
        VatEighteenAndHundredEighteenPersent = 5,

        /// <summary>
        /// НДС чека по ставке 20%
        /// </summary>
        VatTwentyPersent = 6,

        /// <summary>
        /// НДС чека по расчётной ставке 20/120
        /// </summary>
        VatTwentyAndHundredTentyPersent = 7,
    }
}
