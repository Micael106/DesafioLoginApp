using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private SQLiteAsyncConnection _connection;

        public Repository(SQLiteAsyncConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<T>> Get() => await _connection.Table<T>().ToListAsync();
        
        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _connection.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();

        }

        public async Task<T> Get(int id) => await _connection.FindAsync<T>(id);
      
        public async Task<T> Get(Expression<Func<T, bool>> predicate) => await _connection.FindAsync<T>(predicate);

        public async Task<int> Insert(T entity) => await _connection.InsertAsync(entity);

        public async Task<int> InsertOrReplace(T entity) => await _connection.InsertOrReplaceAsync(entity);
        
        public async Task<int> Update(T entity) => await _connection.UpdateAsync(entity);

        public async Task<int> Delete(T entity) => await _connection.DeleteAsync(entity);
        
    }
}
