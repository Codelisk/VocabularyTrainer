using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModule.Extensions
{
    public static class CultureExtensions
    {
        public static string IsoCountryCodeToFlagEmoji(this string country)
        {
            string replacedInvalid = ReplaceInvalidCountrycodes(country);
            return string.Concat(replacedInvalid.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));
        }
        private static string ReplaceInvalidCountrycodes(string country)
        {
            string countryLowercase = country.ToLower();
            switch (countryLowercase)
            {
                case "sq":
                    return "al";
                    break;

                case "uk":
                    return "gb";
                    break;

                case "an":
                    return "nl";
                    break;

                case "ap":
                    return "un";
                    break;

                default:
                    return country;
            }
        }
    }
}
