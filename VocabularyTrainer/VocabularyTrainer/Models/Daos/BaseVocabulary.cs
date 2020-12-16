using SQLite;
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
        public CultureInfo Language { get; set; }
        
    }
}
