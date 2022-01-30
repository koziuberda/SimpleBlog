using System.Threading.Tasks;
using SimpleBlog.Data.Repositories;

namespace SimpleBlog.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPostRepository MessageRepository { get; }
        ICommentRepository RoomRepository { get; }
        Task SaveChangesAsync();
    }
}