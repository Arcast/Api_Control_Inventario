using Inventario_Entities;
using Inventario_Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext Context { get; set; }

        public RepositoryBase(RepositoryContext repositoryContex)
        {
            Context = repositoryContex;
        }

        public void ClearTracker()
        {
            throw new NotImplementedException();
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void CreateRange(IEnumerable<T> entity)
        {
            Context.Set<T>().AddRange(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteNonQuery(string procedure, IEnumerable<IDbDataParameter> param)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll(List<string> includes = null)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                includes.ForEach(prop => query = query.Include(prop));
            }
            return query.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public IQueryable<T> FindAll()
        {
            return Context.Set<T>().AsNoTracking();
        }
    }
}
