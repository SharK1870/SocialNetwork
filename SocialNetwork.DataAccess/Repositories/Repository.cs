using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain.Models;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Context;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SocialNetwork.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private SocialNetworkContext context;

        public Repository(SocialNetworkContext context)
        {
            this.context = context;
        }
        public IQueryable<T> GetAllQuery()
        {
            return context.Set<T>().AsQueryable();
        }
        public ICollection<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Add(T entity)
        {
            return context.Set<T>().Add(entity);
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            return context.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            var entry = context.Entry(entity);
            context.Set<T>().Attach(entity);
            entry.State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            if (context != null)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
}