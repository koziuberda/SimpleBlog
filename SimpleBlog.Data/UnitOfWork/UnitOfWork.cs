using System.Threading.Tasks;
using SimpleBlog.Data.Repositories;

namespace SimpleBlog.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationContext context, IUserRepository userRepository, IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _context = context;
            UserRepository = userRepository;
            PostRepository = postRepository;
            CommentRepository = commentRepository;
        }

        private ApplicationContext _context;

        public IUserRepository UserRepository { get; }
        public IPostRepository PostRepository { get; }
        public ICommentRepository CommentRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}