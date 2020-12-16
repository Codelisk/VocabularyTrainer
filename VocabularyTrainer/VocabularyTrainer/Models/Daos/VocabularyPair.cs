using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyTrainer.Models.Daos
{
    public class VocabularyPair<T>
    {
        public T Vocabulary1 { get; set; }
        public T Vocabulary2 { get; set; }
    }
}
