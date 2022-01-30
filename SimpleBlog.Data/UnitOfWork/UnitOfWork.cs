using System.Threading.Tasks;
using SimpleBlog.Data.Repositories;

namespace SimpleBlog.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationContext context, IUserRepository userRepository, IPostRepository messageRepository, ICommentRepository roomRepository)
        {
            _context = context;
            UserRepository = userRepository;
            MessageRepository = messageRepository;
            RoomRepository = roomRepository;
        }

        private ApplicationContext _context;

        public IUserRepository UserRepository { get; }
        public IPostRepository MessageRepository { get; }
        public ICommentRepository RoomRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}