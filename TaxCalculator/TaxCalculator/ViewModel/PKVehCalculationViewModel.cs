/*
 * Used Vehicle Import Calculation Logic
 * 
 * User provides Factory price 
 * ---> VehFactoryPrice
 * 
 * User provides these incidental costs (VehIncidentalCostAddOpt + VehIncidentalCostAgentFee + VehIncidentalCostFreight)
 * ---> C%F Value = VehFactoryPrice + (VehIncidentalCostAddOpt + VehIncidentalCostAgentFee + VehIncidentalCostFreight)
 * 
 * If User has insurance then add up in C&F value else add 1% C&F value. 
 * ---> CIF = C&F + insurance or CIF = C&F + (C&F * PakistanCountryModel.InsuranceOnCFPercent)
 * 
 * Then Calculate landing charges on CIF value which is 1%
 * ---> VehValueAssessedToTax = CIF + (CIF * PakistanCountryModel.LandingChargeCIFPercent) + VehIncidentalCostOther " + (C&F * PakistanCountryModel.DomesticModelCFPercent)" ---> If domestic model
 * 
 * Now, Calculate Depreciation which is 1% for 1 month to maximum 50%
 * ---> timeInterval = VehDateOfArrival - VehDateOfRegistration
 * ---> months = timeInterval.Days / 30
 * ---> VehDepreciationValue = VehValueAssessedToTax * ( months / 100)
 * 
 * Now, Calculate Custom Duty
 * ---> VehTaxableValue = VehValueAssessedToTax - VehDepreciationValue
 * 
 * Now, Calculate taxes
 * ---> VehCustomDutyValue = VehTaxableValue;
 * ---> VehSalesTaxValue = ( VehTaxableValue + VehCustomDutyValue ) * PakistanCountryModel.SalesTaxPercent;
 * ---> VehIncomeTaxValue = ( VehTaxableValue + VehCustomDutyValue + VehSalesTaxValue) * PakistanCountryModel.IncomeTaxPercent
 * ---> VehExciseDutyValue = ( VehTaxableValue + VehCustomDutyValue ) * PakistanCountryModel.ExciseDutyPercent
 * 
 * Now, Total Tax
 * ---> VehTotalTaxAmount = VehCustomDutyValue + VehSalesTaxValue + VehIncomeTaxValue + VehExciseDutyValue
 * 
 * Now, Total Cost
 * ---> VehTotalCost = VehPurchasePrice + VehTotalTaxAmount
 */


using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculator.CountryProfiles;
using TaxCalculator.Extensions;
using TaxCalculator.Model;

namespace TaxCalculator.ViewModel
{
    public class PKVehCalculationViewModel : BaseViewModel
    {
        #region flagged variables
        public PKVehCalculationModel _pKVehCalculation;
        private EngineDisplacement _selectedEngineDisplacement;
        private MultilingualCulture _selectedCulture;
        #endregion

        #region Properties Related to calculate Tax

        public double VehSalesTaxValue
        {
            get => _pKVehCalculation.VehSalesTaxValue;
            private set => SetProperty(ref _pKVehCalculation.VehSalesTaxValue, value, "VehSalesTaxValue");
        }

        public double VehIncomeTaxValue
        {
            get => _pKVehCalculation.VehIncomeTaxValue;
            private set => SetProperty(ref _pKVehCalculation.VehIncomeTaxValue, value, "VehIncomeTaxValue");
        }

        public double VehExciseDutyValue
        {
            get => _pKVehCalculation.VehExciseDutyValue;
            private set => SetProperty(ref _pKVehCalculation.VehExciseDutyValue, value, "VehExciseDutyValue");
        }

        #region Properties Related to Custom Duty

        public double VehCustomDutyValue
        {
            get => _pKVehCalculation.VehCustomDutyValue;
            private set => SetProperty(ref _pKVehCalculation.VehCustomDutyValue, value, "VehCustomDutyValue");
        }

        public double VehTaxableValue
        {
            get => _pKVehCalculation.VehTaxableValue;
            private set => SetProperty(ref _pKVehCalculation.VehTaxableValue, value, "VehTaxableValue");
        }

        #region Variables Related to Calculate Value Assessed

        public double VehValueAssessedToTax
        {
            get => _pKVehCalculation.VehValueAssessedToTax;
            private set => SetProperty(ref _pKVehCalculation.VehValueAssessedToTax, value, "VehValueAssessedToTax");
        }

        public double VehIncidentalCostOther
        {
            get => _pKVehCalculation.VehIncidentalCostOther;
            set => SetProperty(ref _pKVehCalculation.VehIncidentalCostOther, value, "VehIncidentalCostOther");
        }

        public double VehCIFValue
        {
            get => _pKVehCalculation.VehCIFValue;
            private set => SetProperty(ref _pKVehCalculation.VehCIFValue, value, "VehCIFValue");
        }

        public double VehCFValue
        {
            get => _pKVehCalculation.VehCFValue;
            private set => SetProperty(ref _pKVehCalculation.VehCFValue, value, "VehCFValue");
        }

        public double VehLandingCharge
        {
            get => _pKVehCalculation.VehLandingCharge;
            private set => SetProperty(ref _pKVehCalculation.VehLandingCharge, value, "VehLandingCharge");
        }

        #region Properties Related to calculate C&F value 

        public double VehFactoryPrice
        {
            get => _pKVehCalculation.VehFactoryPrice;
            set => SetProperty(ref _pKVehCalculation.VehFactoryPrice, value, "VehFactoryPrice");
        }

        public double VehIncidentalCostAddOpt
        {
            get => _pKVehCalculation.VehIncidentalCostAddOpt;
            set => SetProperty(ref _pKVehCalculation.VehIncidentalCostAddOpt, value, "VehIncidentalCostAddOpt");
        }

        public double VehIncidentalCostAgentFee
        {
            get => _pKVehCalculation.VehIncidentalCostAgentFee;
            set => SetProperty(ref _pKVehCalculation.VehIncidentalCostAgentFee, value, "VehIncidentalCostAgentFee");
        }

        public double VehIncidentalCostFreight
        {
            get => _pKVehCalculation.VehIncidentalCostFreight;
            set => SetProperty(ref _pKVehCalculation.VehIncidentalCostFreight, value, "VehIncidentalCostFreight");
        }

        # region Properties Related to calculate CIF value

        public double VehIncidentalCostInsurance
        {
            get => _pKVehCalculation.VehIncidentalCostInsurance;
            set => SetProperty(ref _pKVehCalculation.VehIncidentalCostInsurance, value, "VehIncidentalCostInsurance");
        }

        #endregion

        #endregion


        #endregion

        #region Properties Related to calculate Depreciation Value

        public double VehDepreciationValue
        {
            get => _pKVehCalculation.VehDepreciationValue;
            private set => SetProperty(ref _pKVehCalculation.VehDepreciationValue, value, "VehDepreciationValue");
        }

        public DateTime VehDateOfRegistration
        {
            get => _pKVehCalculation.VehDateOfRegistration;
            set => SetProperty(ref _pKVehCalculation.VehDateOfRegistration, value, "VehDateOfRegistration");
        }

        public DateTime VehDateOfArrival
        {
            get => _pKVehCalculation.VehDateOfArrival;
            set => SetProperty(ref _pKVehCalculation.VehDateOfArrival, value, "VehDateOfArrival");
        }

        #endregion

        #endregion

        #endregion

        #region Properties to Calculation Total Cost + Tax

        public double VehTotalTaxAmount
        {
            get => _pKVehCalculation.VehTotalTaxAmount;
            private set => SetProperty(ref _pKVehCalculation.VehTotalTaxAmount, value, "VehTotalTaxAmount");
        }

        public double VehPurchasePrice
        {
            get => _pKVehCalculation.VehPurchasePrice;
            set => SetProperty(ref _pKVehCalculation.VehPurchasePrice, value, "VehPurchasePrice");
        }

        public double VehTotalCost
        {
            get => _pKVehCalculation.VehTotalCost;
            private set => SetProperty(ref _pKVehCalculation.VehTotalCost, value, "VehTotalCost");
        }


        #endregion

        #region Other Properties

        public bool IsInsured
        {
            get => _pKVehCalculation.IsInsured;
            set => SetProperty(ref _pKVehCalculation.IsInsured, value, "IsInsured");
        }

        public bool IsDomestic
        {
            get => _pKVehCalculation.IsDomestic;
            set => SetProperty(ref _pKVehCalculation.IsDomestic, value, "IsDomestic");
        }

        public bool IsNew
        {
            get => _pKVehCalculation.IsNew;
            set => SetProperty(ref _pKVehCalculation.IsNew, value, "IsNew");
        }

        public EngineDisplacement SelectedEngineDisplacement
        {
            get => _selectedEngineDisplacement;
            set => SetProperty(ref _selectedEngineDisplacement, value, "SelectedEngineDisplacement");
        }

        public IList<string> EngineDisplacementOptions
        {
            get => Enum.GetNames(typeof(EngineDisplacement)).Select(ed => ed.SplitCamelCaseToEngineDisplacementString()).ToList();
        }

        public MultilingualCulture SelectedCulture
        {
            get => _selectedCulture;
            set => SetProperty(ref _selectedCulture, value, "SelectedCulture");
        }

        public IList<string> CultureOptions
        {
            get => Enum.GetNames(typeof(MultilingualCulture)).ToList();
        }

        #endregion

        public PKVehCalculationViewModel()
        {
            _pKVehCalculation = new PKVehCalculationModel();
            this.PropertyChanged += PKVehCalculationViewModel_PropertyChanged;
        }

        private void PKVehCalculationViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "VehFactoryPrice":
                    CalculateAssignCFValue();
                    CalculateAssignCIFValue();
                    break;

                case "VehIncidentalCostAddOpt":
                    CalculateAssignCFValue();
                    CalculateAssignCIFValue();
                    break;

                case "VehIncidentalCostAgentFee":
                    CalculateAssignCFValue();
                    CalculateAssignCIFValue();
                    break;

                case "VehIncidentalCostFreight":
                    CalculateAssignCFValue();
                    CalculateAssignCIFValue();
                    break;

                case "IsInsured":
                    CalculateAssignCIFValue();
                    break;

                case "VehIncidentalCostInsurance":
                    CalculateAssignCIFValue();
                    break;

                case "VehIncidentalCostOther":
                    CalculateAssignValueAssessedToTax();
                    break;

                case "IsDomestic":
                    CalculateAssignValueAssessedToTax();
                    break;

                case "VehCIFValue":
                    CalculateAssignValueAssessedToTax();
                    break;

                case "VehCFValue":
                    CalculateAssignValueAssessedToTax();
                    break;

                case "VehDateOfArrival":
                    CalculateAssignDepreciationValue();
                    CalculateAssignTaxableValue();
                    break;

                case "VehDateOfRegistration":
                    CalculateAssignDepreciationValue();
                    CalculateAssignTaxableValue();
                    break;

                case "VehTaxableValue":
                    CalculateAssignCustomDutyValue();
                    break;

                case "VehCustomDutyValue":
                    CalculateAssignTaxValues();
                    CalculateAssignTotalTaxesAndSumValues();
                    break;

                case "VehPurchasePrice":
                    CalculateAssignTotalTaxesAndSumValues();
                    break;

                case "SelectedEngineDisplacement":
                    CalculateAssignTaxableValue();
                    CalculateAssignCustomDutyValue();
                    break;

                case "SelectedCulture":
                    CultureSelector.SelectCulture(SelectedCulture);
                    App.Current.MainPage = new MainPage();
                    break;
            }
        }

        #region Private Calculation Methods

        //Step 1: Calculate C&F
        private void CalculateAssignCFValue()
        {
            VehCFValue = VehFactoryPrice + (VehIncidentalCostAddOpt + VehIncidentalCostAgentFee + VehIncidentalCostFreight);
        }

        //Step 2: Calculate CIF
        private void CalculateAssignCIFValue()
        {
            VehCIFValue = (IsInsured) ? VehCFValue + VehIncidentalCostInsurance : VehCFValue + (VehCFValue * PakistanCountryModel.InsuranceOnCFRate);
        }

        //Step 3: Calculate Value Assessed to tax
        private void CalculateAssignValueAssessedToTax()
        {
            VehLandingCharge = VehCIFValue * PakistanCountryModel.LandingChargeCIFRate;
            VehValueAssessedToTax = VehCIFValue + VehLandingCharge + VehIncidentalCostOther;
            VehValueAssessedToTax = (IsDomestic) ? VehValueAssessedToTax + (VehCFValue * PakistanCountryModel.DomesticModelCFRate) : VehValueAssessedToTax;
        }

        //Step 4: Calculate Depreciation value
        private void CalculateAssignDepreciationValue()
        {
            var timeInterval = (VehDateOfArrival.Date >= VehDateOfRegistration) ? VehDateOfArrival - VehDateOfRegistration : TimeSpan.Zero;
            var months = timeInterval.Days / 30;
            var depreciateableMonths = (months > PakistanCountryModel.MaxAllowedDepreciation) ? PakistanCountryModel.MaxAllowedDepreciation : months;
            VehDepreciationValue = VehValueAssessedToTax * ((double)months / 100);
        }

        //Step 5: Calculate Taxable Value
        private void CalculateAssignTaxableValue()
        {
            VehTaxableValue = VehValueAssessedToTax - VehDepreciationValue;
        }

        //Step 6: Calculate Custom Duty*
        private void CalculateAssignCustomDutyValue()
        {
            VehCustomDutyValue = (IsNew) ? VehTaxableValue * PakistanCountryModel.GetCustomDutyRate(SelectedEngineDisplacement) : VehTaxableValue;
        }

        //Step 7: Calculate Remaining Taxes
        private void CalculateAssignTaxValues()
        {
            var sumOfTaxableCustomDuty = VehTaxableValue + VehCustomDutyValue;
            VehSalesTaxValue = sumOfTaxableCustomDuty * PakistanCountryModel.SalesTaxRate;
            VehIncomeTaxValue = (sumOfTaxableCustomDuty + VehSalesTaxValue) * PakistanCountryModel.IncomeTaxRate;
            VehExciseDutyValue = sumOfTaxableCustomDuty * PakistanCountryModel.ExciseDutyRate;
        }

        //Step 8: Sum Taxes and Calculate Total Cost
        private void CalculateAssignTotalTaxesAndSumValues()
        {
            VehTotalTaxAmount = VehCustomDutyValue + VehSalesTaxValue + VehIncomeTaxValue + VehExciseDutyValue;
            VehTotalCost = VehPurchasePrice + VehTotalTaxAmount;
        }
        #endregion
    }
}
