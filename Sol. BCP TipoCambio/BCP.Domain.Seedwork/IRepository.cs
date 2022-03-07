using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BCP.Domain.Seedwork
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() where T : Entity;
        Task<IQueryable<T>> AllAsync<T>() where T : Entity;
        List<T> Find<T>(Filter<T> filter) where T : Entity;
        Task<List<T>> FindAsync<T>(Filter<T> filter) where T : Entity;
        void Insert<T>(T entity) where T : Entity;
        void Insert<T>(IEnumerable<T> list) where T : Entity;
        Task InsertAsync<T>(T entity) where T : Entity;
        Task InsertAsync<T>(IEnumerable<T> list) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Update<T>(IEnumerable<T> list) where T : Entity;
        Task UpdateAsync<T>(T entity) where T : Entity;
        Task UpdateAsync<T>(IEnumerable<T> list) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        Task DeleteAsync<T>(T entity) where T : Entity;
        void Delete<T>(IEnumerable<T> list) where T : Entity;
        Task DeleteAsync<T>(IEnumerable<T> list) where T : Entity;
    }
}
