using EmployeeManagementSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.DataAccess.Configurations.ShiftConfiguration
{
    public class ShiftConfiguration : BaseEntityConfiguration<Shift>
    {
        public override void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder
               .HasKey(e => e.Id);

            builder
               .Property(e => e.StartTime)
               .HasColumnName(nameof(Shift.StartTime))
               .IsRequired();

            builder
              .Property(e => e.EndTime)
              .HasColumnName(nameof(Shift.EndTime))
              .IsRequired();

            builder
               .HasOne(x => x.Employee)
               .WithMany(x => x.Shifts)
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.EmployeeId);

            builder
               .HasOne(x => x.Role)
               .WithMany(x => x.Shifts)
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.RoleId);

            base.Configure(builder);
        }
    }
}
