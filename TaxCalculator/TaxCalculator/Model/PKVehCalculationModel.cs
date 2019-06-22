using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Model
{
    public class PKVehCalculationModel
    {
        #region Variables Related to Custom Duty Calculation

        public double VehFactoryPrice;
        public double VehCustomDutyValue;

        #region Variables Related to calculate Total Import Cost

        public double VehTotalImportCost;
        public double VehIncidentalCostAddOpt; //----> Value of optional / additional accessories
        public double VehIncidentalCostAgentFee; //-----> Local agent’s commission Freight from country originally exported
        public double VehIncidentalCostFreight; //----->  Freight from country originally exported
        public double VehIncidentalCostInsurance; //----->  Insurance from country originally exported
        public double VehIncidentalCostOther;

        #region Variables Related to calculate Depreciation Value

        public DateTime VehDateOfRegistration;
        public DateTime VehDateOfArrival;
        public double VehDepreciationValue;

        #endregion

        #endregion

        #endregion

        #region Variables to Calculation Total Cost + Tax

        public double VehPurchasePrice;
        public double VehTotalCost;

        #region Variables to calculate Total Tax Amount

        public double VehSalesTaxValue;
        public double VehIncomeTaxValue;
        public double VehExciseDutyValue;
        public double VehTotalTaxAmount;

        #endregion

        #endregion
    }
}
