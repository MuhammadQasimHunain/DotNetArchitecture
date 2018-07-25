using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solution.CrossCutting.Mapping;
using Solution.CrossCutting.Utils;

namespace Solution.CrossCutting.EntityFrameworkCore
{
    public class EntityFrameworkCoreRepository<T> : IRelationalRepository<T> where T : class
    {
        protected EntityFrameworkCoreRepository(DbContext context)
        {
            Context = context;
            Context.ChangeTracker.AutoDetectChangesEnabled = false;
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IQueryable<T> Queryable => Set.AsNoTracking();

        private DbSet<T> Set => Context.Set<T>();

        private DbContext Context { get; }

        public void Add(T item)
        {
            Set.Add(item);
        }

        public async Task AddAsync(T item)
        {
            await Set.AddAsync(item).ConfigureAwait(false);
        }

        public void AddRange(IEnumerable<T> list)
        {
            Set.AddRange(list);
        }

        public async Task AddRangeAsync(IEnumerable<T> list)
        {
            await Set.AddRangeAsync(list).ConfigureAwait(false);
        }

        public bool Any()
        {
            return Set.Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return Set.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return Set.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return Set.AnyAsync(where);
        }

        public long Count()
        {
            return Set.LongCount();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return Set.LongCount(where);
        }

        public Task<long> CountAsync()
        {
            return Set.LongCountAsync();
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return Set.LongCountAsync(where);
        }

        public void Delete(object key)
        {
            Set.Remove(Select(key));
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            Set.RemoveRange(List(where));
        }

        public async Task DeleteAsync(object key)
        {
            await Task.Run(() => Delete(key)).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            await Task.Run(() => Delete(where)).ConfigureAwait(false);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).FirstOrDefault();
        }

        public T FirstOrDefault(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).FirstOrDefaultAsync();
        }

        public Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).FirstOrDefaultAsync();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefaultAsync();
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).Project<T, TResult>().FirstOrDefault();
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).Project<T, TResult>().FirstOrDefaultAsync();
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefault();
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefaultAsync();
        }

        public T LastOrDefault(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefault();
        }

        public T LastOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefault();
        }

        public Task<T> LastOrDefaultAsync(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefaultAsync();
        }

        public Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefaultAsync();
        }

        public TResult LastOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).Project<T, TResult>().LastOrDefault();
        }

        public Task<TResult> LastOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).Project<T, TResult>().LastOrDefaultAsync();
        }

        public TResult LastOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefault();
        }

        public Task<TResult> LastOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefaultAsync();
        }

        public IEnumerable<T> List()
        {
            return Set.ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).ToList();
        }

        public IEnumerable<T> List(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).ToList();
        }

        public PagedList<T> List(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<T>(QueryableInclude(include), parameters);
        }

        public PagedList<T> List(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<T>(QueryableWhereInclude(where, include), parameters);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await Set.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await QueryableWhere(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] include)
        {
            return await QueryableInclude(include).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return await QueryableWhereInclude(where, include).ToListAsync().ConfigureAwait(false);
        }

        public T Select(object key)
        {
            return Set.Find(key);
        }

        public Task<T> SelectAsync(object key)
        {
            return Set.FindAsync(key);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).SingleOrDefault();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefault();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).SingleOrDefaultAsync();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefaultAsync();
        }

        public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).Project<T, TResult>().SingleOrDefault();
        }

        public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).Project<T, TResult>().SingleOrDefaultAsync();
        }

        public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefault();
        }

        public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefaultAsync();
        }

        public void Update(T item, object key)
        {
            Context.Entry(Select(key)).CurrentValues.SetValues(item);
        }

        public async Task UpdateAsync(T item, object key)
        {
            await Task.Run(() => Update(item, key)).ConfigureAwait(false);
        }

        private static IQueryable<T> Include(IQueryable<T> queryable, Expression<Func<T, object>>[] properties)
        {
            properties?.ToList().ForEach(property => queryable = queryable.Include(property));
            return queryable;
        }

        private IQueryable<T> QueryableInclude(Expression<Func<T, object>>[] include)
        {
            return Include(Queryable, include);
        }

        private IQueryable<T> QueryableWhere(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where);
        }

        private IQueryable<T> QueryableWhereInclude(Expression<Func<T, bool>> where, Expression<Func<T, object>>[] include)
        {
            return Include(QueryableWhere(where), include);
        }

        private IQueryable<TResult> QueryableWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return QueryableWhere(where).Select(select);
        }
    }
}
