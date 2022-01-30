using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Data.Repositories;
using SimpleBlog.Data.UnitOfWork;

namespace SimpleBlog.Data.DependencyInjection
{
    public static class UnitOfWorkServicesExtensions
    {
        public static IServiceCollection AddRepositoryAndUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}