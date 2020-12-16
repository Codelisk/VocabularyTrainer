using SharedModule.Extensions;
using SharedModule.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModule.Services
{

    public class CultureService : ICultureService
    {
        private readonly List<string> twoLetterIsoOfEuropeCountries = new List<string>
        {
            "AD","AL","AT","AX","BA","BE","BG","BY","CH","CS","CY","CZ","DE","DK","EE","ES","FI","FO","FR","GB","GG","GI","GR","HR","HU","IE","IM","IS","IT","JE","LI","LT","LU","LV","MC","MD","ME","MK","MT","NL","NO","PL","PT","RO","RS","RU","SE","SI","SJ","SK","SM","UA","VA","XK"
        };
        
        public string GetCountryEmoji(CultureInfo culture)
        {
            string isoRegionName = "";
            try
            {
                CultureInfo specificCulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture.Name);
                isoRegionName = new RegionInfo(specificCulture.LCID).TwoLetterISORegionName;
            }
            catch (Exception e)
            {
                isoRegionName = culture.TwoLetterISOLanguageName;
            }
            return isoRegionName.IsoCountryCodeToFlagEmoji();
        }
    }
}