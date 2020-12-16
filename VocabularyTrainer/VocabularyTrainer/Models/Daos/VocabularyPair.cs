using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyTrainer.Models.Daos
{
    public class VocabularyPair<T>
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [TextBlob(nameof(vocabulary1Blob))]
        public T Vocabulary1 { get; set; }
        public string vocabulary1Blob { get; set; }
        [TextBlob(nameof(vocabulary2Blob))]
        public T Vocabulary2 { get; set; }
        public string vocabulary2Blob { get; set; }
    }
}
