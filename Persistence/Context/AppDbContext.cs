using CleanArchitectureDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchtecture.Persistence.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<User>()
                .HasOne(u => u.Post)
                .WithOne(p => p.User)
                .HasForeignKey<Post>(p => p.Id);
        }
    }
}
