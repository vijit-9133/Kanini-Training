using ManytoManyWithoutJunction.Models;
using Microsoft.EntityFrameworkCore;

namespace ManytoManyWithoutJunction.Data
{
    public class DocPatDbContext : DbContext
    {
        public DbSet<Doctor> Doctors{ get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DocPatDbContext(DbContextOptions<DocPatDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Patients)
                .WithMany(p => p.Doctors)
                .UsingEntity(dp=> dp.ToTable("DocPat"));
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, Name = "Dr. Salunkhe", Specialty = "Cardiology" },
                new Doctor { DoctorId = 2, Name = "Dr. Jhatka", Specialty = "Neurology" });
           
            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, Name = "Ramesh" },
                new Patient { PatientId = 2, Name = "Suresh" },
                new Patient { PatientId = 3, Name = "Mahesh" }
            );

        }
    }
}
