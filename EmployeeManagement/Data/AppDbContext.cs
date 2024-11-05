using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace EmployeeManagement.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(false);

            modelBuilder.Entity<Category>()
                .Property(c => c.ParentId)
                .HasDefaultValue(0);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Carpenter", ParentId = 0 },
                new Category { Id = 2, Name = "Driver", ParentId = 0 },
                new Category { Id = 3, Name = "Electrician", ParentId = 0 },
                new Category { Id = 4, Name = "Gardener", ParentId = 0 },
                new Category { Id = 5, Name = "Plumber", ParentId = 0 },
                new Category { Id = 6, Name = "Welder", ParentId = 0 }
            );

            var password = "pass!234";
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            modelBuilder.Entity<User>().HasData(
                new User {
                    Id = 1,
                    FirstName = "Super",
                    LastName = "Admin",
                    Email = "super@admin.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Phone = "1234567",
                    Role = "S"
                },
                new User {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@doe.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Phone = "1234567",
                    Role = "W"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee {
                    Id = 1,
                    UserId = 2,
                    Title = "Master Carpenter",
                    CategoryId = 1
                }
            );
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}