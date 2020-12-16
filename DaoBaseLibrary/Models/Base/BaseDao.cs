using DaoBaseLibrary.Models.Base.Interfaces;
using SQLite;
using SQLiteModule.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DaoBaseLibrary.Models.Base
{
    public abstract class BaseDao<TEntity> : IDao<TEntity> where TEntity : class, new()
    {
        #region Fields

        private readonly IDbContext _dbContext;

        #endregion

        #region Constructors

        protected BaseDao(IDbContext context) => _dbContext = context;

        #endregion

        //ReaderWriterLockSlim insertSlim = new ReaderWriterLockSlim();
        #region IRepository

        public virtual async Task InsertOrReplace(TEntity entity)
        {
            await _dbContext.InsertOrReplace<TEntity>(entity);
        }
        public virtual async Task InsertAll(IEnumerable<TEntity> objects)
        {
            await _dbContext.InsertAll<TEntity>(objects);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await _dbContext.GetCollection<TEntity>();
        public virtual async Task<CreateTableResult> DropAndCreateTable()
        {
            return await _dbContext.DropAndCreateTable<TEntity>();
        }
        public virtual async Task<TEntity> FirstOrDefault()
        {
            try
            {
                return await _dbContext.FirstOrDefault<TEntity>();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate) =>
            (await WithCollection()).Count();

        #endregion

        #region Protected Methods

        protected async Task<List<TEntity>> WithCollection() =>
            await _dbContext.GetCollection<TEntity>();

        #endregion
    }
}

