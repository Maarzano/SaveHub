using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SavedItems> SavedItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<SavedItems>().ToTable("SavedItems");

            modelBuilder.Entity<SavedItems>()
                .HasOne(s => s.User)
                .WithMany(u => u.SavedItems)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
