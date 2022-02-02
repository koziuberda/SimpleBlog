using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Entities;

namespace SimpleBlog.Data
{
    public class ApplicationContext : IdentityDbContext<User>
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
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "45a8dd45-13dc-4d6d-aa99-feb0f8651991",
                Name = "Administrator",
                NormalizedName = "Administrator",
                ConcurrencyStamp = "1"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "f650ba58-dc41-4056-bdbb-fa4d898b1dfb",
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
                Id = "6bd7e596-be9d-438c-8156-0d49f1a24e2d",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com",
                LockoutEnabled = false,
                PhoneNumber = "11111111",
                PasswordHash = passwordHasher.HashPassword(null, "Pa$$w0rd")
            };

            modelBuilder.Entity<User>().HasData(user);
        }

        private static void SeedUsers2Roles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "45a8dd45-13dc-4d6d-aa99-feb0f8651991",
                    UserId = "6bd7e596-be9d-438c-8156-0d49f1a24e2d"
                }
            );

        }
    }
}