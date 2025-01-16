using EmployeeManagementSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DataAccess
{
    public class EmployeeManagementDbContext : DbContext, IEmployeeManagementDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }

        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            AddBaseEntityValues();
            return await SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private void AddBaseEntityValues()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => ((typeof(BaseEntity)).IsInstanceOfType(x.Entity))
                && (x.State == EntityState.Added || x.State == EntityState.Detached || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.Entity is BaseEntity baseEntity)
                {
                    if (entity.State == EntityState.Added)
                    {
                        baseEntity.CreatedAt = DateTime.UtcNow;
                    }

                    if (entity.State == EntityState.Modified)
                    {
                        baseEntity.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }
        }
    }
}
