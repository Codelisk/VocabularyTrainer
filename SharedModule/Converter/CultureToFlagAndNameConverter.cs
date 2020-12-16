using SharedModule.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharedModule.Converter
{
    public class CultureToFlagAndNameConverter : IValueConverter
    {
        private readonly ICultureService _cultureService;
        public CultureToFlagAndNameConverter(ICultureService cultureService)
        {
            this._cultureService = cultureService;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CultureInfo cultureToWorkWith)
            {
                if (parameter?.Equals("DisplayName") == true)
                {
                    return _cultureService.GetCountryEmoji(cultureToWorkWith) + "  " + cultureToWorkWith.DisplayName;
                }
                else if (parameter?.Equals("EnglishName") == true)
                {

                    return _cultureService.GetCountryEmoji(cultureToWorkWith) + "  " + new RegionInfo(cultureToWorkWith.LCID).EnglishName;
                }
                else if (parameter?.Equals("Flag") == true)
                {
                    return _cultureService.GetCountryEmoji(cultureToWorkWith);
                }
                else
                {
                    return _cultureService.GetCountryEmoji(cultureToWorkWith) + "  " + cultureToWorkWith.NativeName;
                }
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
