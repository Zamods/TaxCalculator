using Plugin.Multilingual;
using System.Globalization;

namespace TaxCalculator.Extensions
{
    public static class CultureSelector
    {
        public static void SelectCulture(MultilingualCulture multilingualCulture)
        {
            switch (multilingualCulture)
            {
                case MultilingualCulture.English:
                    CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
                    break;

                case MultilingualCulture.Urdu:
                    CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("ur");
                    break;

                case MultilingualCulture.Default:
                    CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
                    break;
            }
            TaxCalculator.Resources.LanguageResource.Culture = CrossMultilingual.Current.CurrentCultureInfo;
        }
    }

    public enum MultilingualCulture
    {
        Default,
        English,
        Urdu
    };
}
