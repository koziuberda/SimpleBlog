using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}