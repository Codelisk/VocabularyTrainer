using SQLite;
using SQLiteModule.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabularyTrainer.Models.Daos;
using Xamarin.Essentials.Interfaces;

namespace VocabularyTrainer
{
    public class VocabularySqliteConnection : SQLiteAsyncConnection, IVocabularySqliteConnection
    {
        public VocabularySqliteConnection(IFileSystem platform) : base(Path.Combine(platform.AppDataDirectory, "sample1.db"))
        {
            var conn = this.GetConnection();
            conn.CreateTable<OwnVocabulary>();
            conn.CreateTable<VocabularyPair<OwnVocabulary>>();
        }

        public AsyncTableQuery<VocabularyPair<OwnVocabulary>> OwnVocabulary => this.Table<VocabularyPair<OwnVocabulary>>();
    }

    public interface IVocabularySqliteConnection
    {
    }
}
