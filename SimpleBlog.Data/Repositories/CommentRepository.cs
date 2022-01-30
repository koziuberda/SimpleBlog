using SimpleBlog.Entities;

namespace SimpleBlog.Data.Repositories
{
    public class CommentRepository : EfRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}