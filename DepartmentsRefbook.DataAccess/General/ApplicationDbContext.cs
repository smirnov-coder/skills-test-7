using DepartmentsRefbook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartmentsRefbook.DataAccess.General
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .Property(d => d.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<Branch>()
                .Property(b => b.RowVersion)
                .IsRowVersion();
        }
    }
}
