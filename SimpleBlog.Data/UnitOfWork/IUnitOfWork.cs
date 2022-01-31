using System.Threading.Tasks;
using SimpleBlog.Data.Repositories;

namespace SimpleBlog.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        ICommentRepository CommentRepository { get; }
        Task SaveChangesAsync();
    }
}