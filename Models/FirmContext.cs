using Microsoft.EntityFrameworkCore;

namespace iTi_day_17_lab.Models
{
    public class FirmContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentLocations> DepartmentLocations { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<WorksOn> WorksOns { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql("Host=localhost;Username=postgres;Password=root;Database=Firm");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentLocations>().HasKey(d => new { d.DepartmentId, d.Location});
            modelBuilder.Entity<WorksOn>().HasKey(w => new { w.EmployeeSSN, w.ProjectId});
            modelBuilder.Entity<Dependent>().HasKey(d => new { d.EmployeeSSN, d.Name});
            base.OnModelCreating(modelBuilder);
        }
    }
}
