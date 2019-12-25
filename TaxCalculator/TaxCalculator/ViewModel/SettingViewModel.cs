using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using TaxCalculator.Extensions;

namespace TaxCalculator.ViewModel
{
    public class SettingViewModel : BaseViewModel
    {
        #region Flagged Variables
        private MultilingualCulture _selectedCulture;
        #endregion

        #region Properties

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

        #region Constructor

        public SettingViewModel()
        {
            this.PropertyChanged += SettingViewModel_PropertyChanged;
        }

        private void SettingViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedCulture":
                    CultureSelector.SelectCulture(SelectedCulture);
                    App.InitializeNavigation();
                    break;
            }
        }

        #endregion
    }
}
