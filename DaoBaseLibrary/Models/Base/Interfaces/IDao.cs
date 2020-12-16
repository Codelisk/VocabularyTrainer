using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DaoBaseLibrary.Models.Base.Interfaces
{
    public interface IDao<TEntity> where TEntity : class, new()
    {
        Task<int> Count(Expression<Func<TEntity, bool>> predicate);
        Task<CreateTableResult> DropAndCreateTable();
        Task<TEntity> FirstOrDefault();
        Task<IEnumerable<TEntity>> GetAll();
        Task InsertAll(IEnumerable<TEntity> objects);
        Task InsertOrReplace(TEntity entity);
    }
}