using Employee_Section.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Section.Context
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // TODO: Строка соединения с базой данных.
            optionsBuilder.UseSqlServer(@"");

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.FullName)
                .IsUnique();
        }
    }
}
