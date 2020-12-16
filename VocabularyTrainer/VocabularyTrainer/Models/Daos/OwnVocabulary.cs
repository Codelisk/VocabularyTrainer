using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyTrainer.Models.Daos
{
    public class OwnVocabulary : BaseVocabulary
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
