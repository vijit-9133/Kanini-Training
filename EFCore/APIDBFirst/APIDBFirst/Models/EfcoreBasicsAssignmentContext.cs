using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIDBFirst.Models;

public partial class EfcoreBasicsAssignmentContext : DbContext
{
    public EfcoreBasicsAssignmentContext()
    {
    }

    public EfcoreBasicsAssignmentContext(DbContextOptions<EfcoreBasicsAssignmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=VIJIT_SHETTY;initial catalog=EFCoreBasicsAssignment;integrated security=true;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasIndex(e => e.ManufacturerId, "IX_Cars_ManufacturerId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Cars).HasForeignKey(d => d.ManufacturerId);
        });
        modelBuilder.Entity<Manufacturer>(entity =>
        {
            
            entity.Property(e => e.Name).IsRequired();
            entity.Property(c => c.Country);
            
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
