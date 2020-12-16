using SQLite;
using SQLiteModule.Services.Interfaces;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials.Interfaces;

namespace SQLiteModule.Services
{
    public sealed class SQLiteContext: BaseDatabase, IDbContext
    {
        public SQLiteContext(IFileSystem fileSystem):base(fileSystem.AppDataDirectory,"vdb.db3")
        {
        }
        public async Task<List<TEntity>> GetCollection<TEntity>() where TEntity : class, new()
        {
            var databaseConnection = await GetDatabaseConnection<TEntity>().ConfigureAwait(false);
            await CreateTableAsync<TEntity>().ConfigureAwait(false);
            var result = await AttemptAndRetry(() => databaseConnection.GetAllWithChildrenAsync<TEntity>()).ConfigureAwait(false);
            return result;
        }
        public async Task<CreateTableResult> DropAndCreateTable<TEntity>() where TEntity : class, new()
        {
            var databaseConnection = await GetDatabaseConnection<TEntity>().ConfigureAwait(false);
            await AttemptAndRetry(() => databaseConnection.DropTableAsync<TEntity>()).ConfigureAwait(false);

            var result = await CreateTableAsync<TEntity>().ConfigureAwait(false);
            return result;
        }
        private async Task<CreateTableResult> CreateTableAsync<TEntity>() where TEntity : class, new()
        {
            var databaseConnection = await GetDatabaseConnection<TEntity>().ConfigureAwait(false);
            return await AttemptAndRetry(() => databaseConnection.CreateTableAsync<TEntity>()).ConfigureAwait(false);
        }
        public async Task InsertOrReplace<TEntity>(object obj)
        {
            var databaseConnection = await GetDatabaseConnection<TEntity>().ConfigureAwait(false);
            await AttemptAndRetry<TEntity>(() => databaseConnection.InsertOrReplaceWithChildrenAsync(obj)).ConfigureAwait(false);
        }
        public async Task InsertAll<TEntity>(IEnumerable<TEntity> objs) where TEntity : class, new()
        {
            var databaseConnection = await GetDatabaseConnection<TEntity>().ConfigureAwait(false);
            await CreateTableAsync<TEntity>().ConfigureAwait(false);
            await AttemptAndRetry<TEntity>(() => databaseConnection.InsertOrReplaceAllWithChildrenAsync(objs)).ConfigureAwait(false);
        }
        public async Task<TEntity> FirstOrDefault<TEntity>() where TEntity : class, new()
        {
            try
            {
                var coll = await GetCollection<TEntity>().ConfigureAwait(false);
                var result = coll.FirstOrDefault();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async override Task<int> DeleteAllData<TEntity>()
        {
            var databaseConnection = await GetDatabaseConnection<TEntity>().ConfigureAwait(false);
            return await AttemptAndRetry(() => databaseConnection.DeleteAllAsync<TEntity>()).ConfigureAwait(false);
        }
    }
}