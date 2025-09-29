using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Models;

public partial class Kaninibatch2Context : DbContext
{
    public Kaninibatch2Context(DbContextOptions<Kaninibatch2Context> options)
        : base(options)
    {
    }

   
    public virtual DbSet<Student> Students { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=VIJIT_SHETTY;initial catalog=KANINIBATCH2;integrated security = true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__STUDENT__E69FE77B063A3111");

            entity.ToTable("STUDENT");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Courseid).HasColumnName("COURSEID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

     void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
    }
}
