using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleBlog.Entities;

namespace SimpleBlog.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    { 
        Task<Post> GetWithCommentsAsync(int id);
    }
}