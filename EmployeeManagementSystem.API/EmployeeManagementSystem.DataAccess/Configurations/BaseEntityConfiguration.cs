using EmployeeManagementSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.DataAccess.Configurations
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .Property(e => e.CreatedAt)
                .HasColumnName(nameof(BaseEntity.CreatedAt))
                .IsRequired();

            builder
                .Property(e => e.UpdatedAt)
                .HasColumnName(nameof(BaseEntity.UpdatedAt));
        }
    }
}
