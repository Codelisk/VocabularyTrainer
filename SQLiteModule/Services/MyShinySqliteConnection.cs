using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials.Interfaces;

namespace SQLiteModule.Services
{
    public class MyShinySqliteConnection : SQLiteAsyncConnection
    {
        public MyShinySqliteConnection(IFileSystem platform) : base(Path.Combine(platform.AppDataDirectory, "sample.db"))
        {
            var conn = this.GetConnection();
            //conn.CreateTable<BeaconEvent>();
        }


        //public AsyncTableQuery<BeaconEvent> BeaconEvents => this.Table<BeaconEvent>();
    }
}
