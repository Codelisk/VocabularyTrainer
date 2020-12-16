using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabularyTrainer.Models.Daos;

namespace VocabularyTrainer.Constants
{
    public class SampleData
    {
        public static List<BaseVocabulary> Vocabularies = new List<BaseVocabulary>
        {
            new BaseVocabulary
            {
                Language=CultureInfo.CurrentCulture,
                Text ="drucken"
            },new BaseVocabulary
            {
                Language=CultureInfo.GetCultureInfo("en-GB"),
                Text ="print"
            },
        };
    }
}
