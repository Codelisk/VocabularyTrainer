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
using SQLiteNetExtensionsAsync.Extensions;

namespace VocabularyTrainer
{
    public class VocabularySqliteConnection : SQLiteAsyncConnection
    {
        public VocabularySqliteConnection(IFileSystem platform) : base(Path.Combine(platform.AppDataDirectory, "sample7.db"))
        {
            var conn = this.GetConnection();
            try
            {
                conn.CreateTable<OwnVocabulary>();
                conn.CreateTable<VocabularyPair<OwnVocabulary>>();
            }
            catch(Exception e)
            {

            }
        }

        public AsyncTableQuery<VocabularyPair<OwnVocabulary>> OwnVocabulary => this.Table<VocabularyPair<OwnVocabulary>>();
    }
}
