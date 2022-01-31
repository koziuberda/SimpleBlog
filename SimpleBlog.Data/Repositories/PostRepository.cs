using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Entities;

namespace SimpleBlog.Data.Repositories
{
    public class PostRepository : EfRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Post> GetWithCommentsAsync(int id)
        {
            return await _dbSet.Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}