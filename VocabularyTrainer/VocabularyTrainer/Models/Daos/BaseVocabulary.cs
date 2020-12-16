using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyTrainer.Models.Daos
{
    public class BaseVocabulary
    {
        public string Text { get; set; }
        [TextBlob(nameof(languageBlobbed))]
        public CultureInfo Language { get; set; }
        public string languageBlobbed { get; set; }

    }
}
