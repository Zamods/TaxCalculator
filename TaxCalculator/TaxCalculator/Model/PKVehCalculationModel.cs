using System;

namespace TaxCalculator.Model
{
    public class PKVehCalculationModel
    {
        #region Variables Related to calculate Tax
        public double VehSalesTaxValue;
        public double VehIncomeTaxValue;
        public double VehExciseDutyValue;

        #region Variables Related to Custom Duty

        public double VehCustomDutyValue;
        public double VehTaxableValue;

        #region Variables Related to Calculate Value Assessed

        public double VehValueAssessedToTax;
        public double VehIncidentalCostOther;
        public double VehCIFValue;
        public double VehCFValue;
        public double VehLandingCharge;

        #region Variables Related to calculate C&F value 

        public double VehFactoryPrice;
        public double VehIncidentalCostAddOpt; //----> Value of optional / additional accessories
        public double VehIncidentalCostAgentFee; //-----> Local agent’s commission Freight from country originally exported
        public double VehIncidentalCostFreight; //----->  Freight from country originally exported


        # region Variables Related to calculate CIF value

        public double VehIncidentalCostInsurance; //----->  Insurance from country originally exported

        #endregion

        #endregion


        #endregion

        #region Variables Related to calculate Depreciation Value

        public DateTime VehDateOfRegistration;
        public DateTime VehDateOfArrival;
        public double VehDepreciationValue;

        #endregion

        #endregion

        #endregion

        #region Variables to Calculation Total Cost + Tax

        public double VehPurchasePrice;
        public double VehTotalTaxAmount;
        public double VehTotalCost;

        #endregion

        #region Other Variables

        public bool IsInsured = true;
        public bool IsDomestic = false;
        public bool IsNew = false;

        #endregion
    }
}
