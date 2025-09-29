using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeOne.Domain; 

namespace PracticeOne.Data
{
    public class PlayerSportDbContext : DbContext
    {
        public PlayerSportDbContext(DbContextOptions<PlayerSportDbContext> options) : base(options)
        { 
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<PlayerSport> PlayerSports { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasKey(ps =>  ps.PlayerId);
            modelBuilder.Entity<Player>()
                 .Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Sport>()
                 .HasKey( s => s.SportId);
            modelBuilder.Entity<Sport>()
                .Property(s => s.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<PlayerSport>(
                sp =>
                {
                    sp.HasKey(ps => new { ps.PlayerId, ps.SportId });
                    sp.HasOne(ps => ps.Player)
                        .WithMany(p => p.PlayerSports)
                        .HasForeignKey(ps => ps.PlayerId)
                        .OnDelete(DeleteBehavior.Cascade);
                    

                    sp.HasOne(ps => ps.Sport)
                        .WithMany(s => s.PlayerSports)
                        .HasForeignKey(ps => ps.SportId)
                        .OnDelete(DeleteBehavior.Cascade);
                    

                }
                );


        }

    }
}
