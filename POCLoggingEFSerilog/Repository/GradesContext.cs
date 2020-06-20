using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POCLoggingEFSerilog.Entity;

namespace POCLoggingEFSerilog.Repository
{
    public class GradesContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public GradesContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("grades");

            modelBuilder.Entity<Student>().ToTable("student");
            modelBuilder.Entity<Student>().HasKey("Id");
            modelBuilder.Entity<Student>().Property("Name").HasColumnName("name");            

            modelBuilder.Entity<Subject>().ToTable("subject");
            modelBuilder.Entity<Subject>().HasKey("Id");
            modelBuilder.Entity<Subject>().Property("Name").HasColumnName("name");

            modelBuilder.Entity<Grade>().ToTable("student_grade");
            modelBuilder.Entity<Grade>().HasKey("Id");
            modelBuilder.Entity<Grade>().Property("StudentId").HasColumnName("student_id");
            modelBuilder.Entity<Grade>().Property("SubjectId").HasColumnName("subject_id");
            modelBuilder.Entity<Grade>().Property("Value").HasColumnName("grade");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
