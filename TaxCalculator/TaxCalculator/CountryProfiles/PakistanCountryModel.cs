using TaxCalculator.Model;

namespace TaxCalculator.CountryProfiles
{
    public class PakistanCountryModel : BaseCountryModel
    {
        public static double LandingChargeCIFRate { get; } = 1.00 / 100;
        public static double DomesticModelCFRate { get; } = 5.00 / 100;
        public static double InsuranceOnCFRate { get; } = 1.00 / 100;
        public static double SalesTaxRate { get; } = 17.00 / 100 ;
        public static double IncomeTaxRate { get; } = 5.00 / 100;
        public static double ExciseDutyRate { get; } = 1.00 / 100;
        public static int MaxAllowedDepreciation { get; } = 50;

        public static double GetCustomDutyRate(EngineDisplacement displacement)
        {
            double customDutyRate;
            switch (displacement)
            {
                case EngineDisplacement.UptoED800cc: 
                     customDutyRate = 50.00 / 100;
                    break;

                case EngineDisplacement.ED801cctoED1000cc:
                    customDutyRate = 55.00 / 100;
                    break;

                case EngineDisplacement.ED1001cctoED1300cc:
                    customDutyRate = 60.00 / 100;
                    break;

                case EngineDisplacement.ED1301cctoED1500cc:
                    customDutyRate = 75.00 / 100;
                    break;

                case EngineDisplacement.ED1501cctoED1600cc:
                    customDutyRate = 75.00 / 100;
                    break;

                case EngineDisplacement.ED1801cctoAbove:
                    customDutyRate = 100.00 / 100;
                    break;

                default:
                    customDutyRate = 0;
                    break;
            }
            return customDutyRate;
        }     
    }

    public enum EngineDisplacement
    {
        UptoED800cc,
        ED801cctoED1000cc,
        ED1001cctoED1300cc,
        ED1301cctoED1500cc,
        ED1501cctoED1600cc,
        ED1601cctoED1800cc,
        ED1801cctoAbove
    };

}
