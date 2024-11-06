using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Infra
{
    public class ProvaMarqDbContext : DbContext
    {
        public ProvaMarqDbContext(DbContextOptions<ProvaMarqDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Company>().HasIndex(c => c.Document).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.Document).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.PIN).IsUnique();

            modelBuilder.Entity<Company>().Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(e => e.Name).HasMaxLength(100);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}