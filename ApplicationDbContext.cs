using CQRS_Users.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Users
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
