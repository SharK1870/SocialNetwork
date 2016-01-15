using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Abstract
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAllQuery();
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        T GetById(int id);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entity);
        void Delete(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void Update(T entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
