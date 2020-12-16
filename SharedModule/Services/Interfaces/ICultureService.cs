using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModule.Services.Interfaces
{
    public interface ICultureService
    {
        string GetCountryEmoji(CultureInfo culture);
    }
}
