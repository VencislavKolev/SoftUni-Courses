
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);

                entity
                    .Property(p => p.FirstName)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(50);

                entity
                    .Property(p => p.LastName)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(50);

                entity
                    .Property(p => p.Address)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(250);

                entity
                    .Property(p => p.Email)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(v => v.VisitationId);

                entity
                   .Property(v => v.Comments)
                   .IsUnicode()
                   .IsRequired()
                   .HasMaxLength(250);

                entity
                    .HasOne(v => v.Patient)
                    .WithMany(p => p.Visitations)
                    .HasForeignKey(v => v.PatientId);

                entity
                    .HasOne(v => v.Doctor)
                    .WithMany(v => v.Visitations)
                    .HasForeignKey(v => v.DoctorId);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(d => d.DiagnoseId);

                entity
                  .Property(d => d.Name)
                  .IsUnicode()
                  .IsRequired()
                  .HasMaxLength(50);

                entity
                   .Property(d => d.Comments)
                   .IsUnicode()
                   .IsRequired()
                   .HasMaxLength(250);

                entity
                    .HasOne(d => d.Patient)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.MedicamentId);

                entity
                   .Property(m => m.Name)
                   .IsUnicode()
                   .IsRequired()
                   .HasMaxLength(50);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.MedicamentId, pm.PatientId });

                entity
                    .HasOne(pm => pm.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(pm => pm.PatientId);

                entity
                    .HasOne(pm => pm.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(pm => pm.MedicamentId);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.DoctorId);

                entity
                    .Property(d => d.Name)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(100);

                entity
                    .Property(d => d.Specialty)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(100);

            });
        }
    }
}
