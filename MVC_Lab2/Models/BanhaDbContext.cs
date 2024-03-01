using Microsoft.EntityFrameworkCore;
namespace MVC_Lab2.Models
{
    public class BanhaDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorksFor> WorksFor { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer("Server=DESKTOP-IDORBHT;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.Dno);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Supervisor)
                .WithMany()
                .HasForeignKey(e => e.Superssn);

            modelBuilder.Entity<Dependent>()
                .HasOne(d => d.Employee)
                .WithMany(e => e.Dependents)
                .HasForeignKey(d => d.ESSN);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.Dno);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.Dno);

            modelBuilder.Entity<WorksFor>()
                .HasOne(w => w.Employee)
                .WithMany(e => e.WorkAssignments)
                .HasForeignKey(w => w.ESSN);

            modelBuilder.Entity<WorksFor>()
                .HasOne(w => w.Project)
                .WithMany(p => p.WorkAssignments)
                .HasForeignKey(w => w.Pno);
            modelBuilder.Entity<WorksFor>().HasKey(w => new { w.ESSN, w.Pno });

        }
    }
}
