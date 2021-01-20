using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
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
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity
                    .Property(s => s.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity
                    .Property(s => s.PhoneNumber)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity
                    .Property(s => s.Birthday)
                    .IsRequired(false);

            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity
                    .Property(c => c.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(80);

                entity
                    .Property(c => c.Description)
                    .IsRequired(false)
                    .IsUnicode();

                entity
                    .Property(c => c.StartDate)
                    .HasColumnType("DATETIME2");

                entity
                    .Property(c => c.EndDate)
                    .HasColumnType("DATETIME2");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity
                    .Property(r => r.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity
                    .Property(r => r.Url)
                    .IsRequired()
                    .IsUnicode(false);

                entity
                    .HasOne(r => r.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity
                    .Property(h => h.Content)
                    .IsRequired()
                    .IsUnicode(false);

                entity
                    .HasOne(h => h.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(h => h.StudentId);

                entity
                    .HasOne(h => h.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity
                    .HasOne(sc => sc.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId);

                entity
                    .HasOne(sc => sc.Course)
                    .WithMany(s => s.StudentCourse)
                    .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}
