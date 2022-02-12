using BalletStudio.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BalletStudio.Data
{
    public class BalletStudioDbContext : IdentityDbContext
    {
        public BalletStudioDbContext(DbContextOptions<BalletStudioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dancer> Dancers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
