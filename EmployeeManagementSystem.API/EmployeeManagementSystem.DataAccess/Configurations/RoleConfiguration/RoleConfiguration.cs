using EmployeeManagementSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.DataAccess.Configurations.RoleConfiguration
{
    public class RoleConfiguration : BaseEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
               .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .HasColumnName(nameof(Role.Name))
                .IsRequired();

            base.Configure(builder);
        }
    }
}
