using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Model;
using Xamarin.Forms;

namespace TaxCalculator.ViewModel
{
    public class PKVehCalculationViewModel : BaseViewModel
    {
        #region flagged variables
        public PKVehCalculationModel _pKVehCalculation;
        #endregion

        #region PKVehCalculationModel Properties Getters or Setters

        #region Properties related to calculate Custom Duty

        public double VehFactoryPrice
        {
            get => _pKVehCalculation.VehFactoryPrice;
            set
            {
                if (SetProperty(ref _pKVehCalculation.VehFactoryPrice, value, "VehFactoryPrice"))
                {
                    VehCustomDutyValue = CalculateTotalCustomDuty();
                }
            }
        }

        public double VehCustomDutyValue
        {
            get => _pKVehCalculation.VehCustomDutyValue;
            private set
            {
                if (SetProperty(ref _pKVehCalculation.VehCustomDutyValue, value, "VehCustomDutyValue"))
                {
                    VehTotalTaxAmount = CalculateTotalTaxAmount();
                }
            }
        }

        #region Properties Related to calculate Total Import Cost

        public double VehIncidentalCostAddOpt
        {
            get => _pKVehCalculation.VehIncidentalCostAddOpt;
            set
            {
                if (SetProperty(ref _pKVehCalculation.VehIncidentalCostAddOpt, value, "VehIncidentalCostAddOpt"))
                {
                    VehTotalImportCost = CalculateTotalImportCost();
                }
            }
        }

        public double VehIncidentalCostAgentFee
        {
            get => _pKVehCalculation.VehIncidentalCostAgentFee;
            set
            {
                if (SetProperty(ref _pKVehCalculation.VehIncidentalCostAgentFee, value, "VehIncidentalCostAgentFee"))
                {
                    VehTotalImportCost = CalculateTotalImportCost();
                }
            }
        }

        public double VehIncidentalCostFreight
        {
            get => _pKVehCalculation.VehIncidentalCostFreight;
            set
            {
                if (SetProperty(ref _pKVehCalculation.VehIncidentalCostFreight, value, "VehIncidentalCostFreight"))
                {
                    VehTotalImportCost = CalculateTotalImportCost();
                }
            }
        }

        public double VehIncidentalCostInsurance
        {
            get => _pKVehCalculation.VehIncidentalCostInsurance;
            set
            {
                if (SetProperty(ref _pKVehCalculation.VehIncidentalCostInsurance, value, "VehIncidentalCostInsurance"))
                {
                    VehTotalImportCost = CalculateTotalImportCost();
                }
            }
        }

        public double VehIncidentalCostOther
        {
            get => _pKVehCalculation.VehIncidentalCostOther;
            set
            {
                if (SetProperty(ref _pKVehCalculation.VehIncidentalCostOther, value, "VehIncidentalCostOther"))
                {
                    VehTotalImportCost = CalculateTotalImportCost();
                }
            }
        }

        public double VehTotalImportCost
        {
            get => _pKVehCalculation.VehTotalImportCost;
            private set
            {
                if(SetProperty(ref _pKVehCalculation.VehTotalImportCost, value, "VehTotalImportCost"))
                {
                    VehDepreciationValue = CalculateDepreciationValue();
                    VehCustomDutyValue = CalculateTotalCustomDuty();
                } 
            }
        }

        #region Properties related to Depreciation Calculation

        public double VehDepreciationValue
        {
            get => _pKVehCalculation.VehDepreciationValue;
            private set
            {
                if(SetProperty(ref _pKVehCalculation.VehDepreciationValue, value, "VehDepreciationValue"))
                {
                    VehCustomDutyValue = CalculateTotalCustomDuty();
                }
            }
        }

        public DateTime VehDateOfRegistration
        {
            get => _pKVehCalculation.VehDateOfRegistration;
            set
            {
                if(SetProperty(ref _pKVehCalculation.VehDateOfRegistration, value, "VehDateOfRegistration"))
                {
                    VehDepreciationValue = CalculateDepreciationValue();
                }
            }
        }

        public DateTime VehDateOfArrival
        {
            get => _pKVehCalculation.VehDateOfArrival;
            set
            {
                if(SetProperty(ref _pKVehCalculation.VehDateOfArrival, value, "VehDateOfArrival"))
                {
                    VehDepreciationValue = CalculateDepreciationValue();
                }
            }
        }

        #endregion

        #endregion

        #endregion

        #region Properties to Calculate Total Tax Amount

        public double VehSalesTaxValue
        {
            get => _pKVehCalculation.VehSalesTaxValue;
            private set => SetProperty(ref _pKVehCalculation.VehSalesTaxValue, value , "VehSalesTaxValue");
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

        public double VehTotalTaxAmount
        {
            get => _pKVehCalculation.VehTotalTaxAmount;
            private set
            {
                if (SetProperty(ref _pKVehCalculation.VehTotalTaxAmount, value, "VehTotalTaxAmount"))
                {
                    VehTotalCost = CalculateVehicleTotalCost();
                }
            }
        }

        #endregion

        public double VehPurchasePrice
        {
            get => _pKVehCalculation.VehPurchasePrice;
            set
            {
                if(SetProperty(ref _pKVehCalculation.VehPurchasePrice, value, "VehPurchasePrice"))
                {
                    VehTotalCost = CalculateVehicleTotalCost();
                }
            } 
        }

        public double VehTotalCost
        {
            get => _pKVehCalculation.VehTotalCost;
            private set => SetProperty(ref _pKVehCalculation.VehTotalCost, value, "VehTotalCost");
        }

        #endregion

        #region Local methods for handling logical calculations

        private double CalculateVehicleTotalCost()
        {
            return _pKVehCalculation.VehPurchasePrice + _pKVehCalculation.VehTotalTaxAmount;
        }

        private double CalculateDepreciationValue()
        {
            var timeInterval = (VehDateOfArrival.Date >= VehDateOfRegistration) ? VehDateOfArrival - VehDateOfRegistration : TimeSpan.Zero;
            var months = timeInterval.Days / 30;
            var depreciateableMonths = (months > PakistanCountryModel.MaxAllowedDepreciation) ? PakistanCountryModel.MaxAllowedDepreciation : months;
            return (_pKVehCalculation.VehFactoryPrice + _pKVehCalculation.VehTotalImportCost) * ((double)depreciateableMonths / 100);
        }

        private double CalculateTotalImportCost()
        {
            return _pKVehCalculation.VehIncidentalCostAddOpt + _pKVehCalculation.VehIncidentalCostAgentFee
                 + _pKVehCalculation.VehIncidentalCostFreight + _pKVehCalculation.VehIncidentalCostInsurance
                 + _pKVehCalculation.VehIncidentalCostOther;
        }

        private double CalculateTotalCustomDuty()
        {
            return (_pKVehCalculation.VehFactoryPrice + _pKVehCalculation.VehTotalImportCost) - _pKVehCalculation.VehDepreciationValue;
        }
        
        private double CalculateSalesTaxAmount()
        {
            return VehSalesTaxValue = (_pKVehCalculation.VehFactoryPrice + _pKVehCalculation.VehCustomDutyValue) * PakistanCountryModel.SalesTaxPercent;
        }

        private double CalculateIncomeTaxAmount()
        {
            return VehIncomeTaxValue = (_pKVehCalculation.VehFactoryPrice + _pKVehCalculation.VehCustomDutyValue + _pKVehCalculation.VehSalesTaxValue) * PakistanCountryModel.IncomeTaxPercent;
        }

        private double CalculateExciseDutyAmount()
        {
            return VehExciseDutyValue = (_pKVehCalculation.VehFactoryPrice + _pKVehCalculation.VehCustomDutyValue) * PakistanCountryModel.ExciseDutyPercent;
        }

        private double CalculateTotalTaxAmount()
        {
            return _pKVehCalculation.VehCustomDutyValue + CalculateSalesTaxAmount() + CalculateIncomeTaxAmount() + CalculateExciseDutyAmount();
        }
        #endregion

        public PKVehCalculationViewModel()
        {
            _pKVehCalculation = new PKVehCalculationModel();
            PerformCalculations(ref _pKVehCalculation);
        }

        private void PerformCalculations(ref PKVehCalculationModel calculationModel)
        {
            calculationModel.VehDepreciationValue = CalculateDepreciationValue();
            calculationModel.VehTotalImportCost = CalculateTotalImportCost();
            calculationModel.VehCustomDutyValue = CalculateTotalCustomDuty();
            calculationModel.VehTotalTaxAmount = CalculateTotalTaxAmount();
            calculationModel.VehTotalCost = CalculateVehicleTotalCost();
        }

        public PropertyChangingEventHandler eventHandler;
       
        
    }
}
