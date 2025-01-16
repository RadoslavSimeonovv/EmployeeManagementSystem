using EmployeeManagementSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.DataAccess.Configurations.EmployeeRolesConfiguration
{
    public class EmployeeRolesConfiguration : BaseEntityConfiguration<EmployeeRoles>
    {
        public override void Configure(EntityTypeBuilder<EmployeeRoles> builder)
        {
            builder
                .HasKey(e => new { e.EmployeeId, e.RoleId });

            builder
                .HasOne(e => e.Employee)
                .WithMany(s => s.EmployeeRoles)
                .HasForeignKey(e => e.EmployeeId);

            builder
                .HasOne(e => e.Role)
                .WithMany(c => c.EmployeeRoles)
                .HasForeignKey(e => e.RoleId);

            base.Configure(builder);
        }
    }
}
