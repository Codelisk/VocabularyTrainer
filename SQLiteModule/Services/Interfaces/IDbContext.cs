using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteModule.Services.Interfaces
{
    public interface IDbContext
    {
        Task<CreateTableResult> DropAndCreateTable<TEntity>() where TEntity : class, new();
        Task<TEntity> FirstOrDefault<TEntity>() where TEntity : class, new();
        Task<List<TEntity>> GetCollection<TEntity>() where TEntity : class, new();
        Task InsertAll<TEntity>(IEnumerable<TEntity> objs) where TEntity : class, new();
        Task InsertOrReplace<TEntity>(object obj);
    }
}
