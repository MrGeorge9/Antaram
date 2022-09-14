using Antaram_game.Models;
using Microsoft.EntityFrameworkCore;

namespace Antaram_game.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Character)
                .WithOne(u => u.User)
                .HasForeignKey<Character>(k => k.UserId);
        }
    }
}
