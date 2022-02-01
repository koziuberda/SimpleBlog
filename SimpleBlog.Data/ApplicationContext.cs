using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Entities;

namespace SimpleBlog.Data
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
            SeedUsers2Roles(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "Admin",
                ConcurrencyStamp = "1"
            });

            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 2,
                Name = "User",
                NormalizedName = "User",
                ConcurrencyStamp = "2"
            });
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<User>();
            
            var user = new User
            {
                Id = 15,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com",
                Firstname = "Name",
                Lastname = "Surname",
                LockoutEnabled = false,
                PasswordHash = passwordHasher.HashPassword(null, "Pa$$w0rd")
            };

            modelBuilder.Entity<User>().HasData(user);
        }

        private static void SeedUsers2Roles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 1,
                    UserId = 15
                }
            );

        }
    }
}