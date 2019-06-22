using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Model
{
    public class PakistanCountryModel : BaseCountryModel
    {
        public static double SalesTaxPercent { get; } = 17.00 / 100 ;
        public static double IncomeTaxPercent { get; } = 5.00 / 100;
        public static double ExciseDutyPercent { get; } = 1.00 / 100;
        public static int MaxAllowedDepreciation { get; } = 50;
    }
}
