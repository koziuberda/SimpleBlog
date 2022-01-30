using SimpleBlog.Entities;

namespace SimpleBlog.Data.Repositories
{
    public class PostRepository : EfRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context)
        {
        }
    }
}