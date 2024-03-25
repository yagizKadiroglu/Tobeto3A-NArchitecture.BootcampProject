using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.Username).HasColumnName("Username");
        builder.Property(e => e.FirstName).HasColumnName("FirstName");
        builder.Property(e => e.LastName).HasColumnName("LastName");
        builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth");
        builder.Property(e => e.NationalIdentity).HasColumnName("NationalIdentity");
        builder.Property(e => e.Email).HasColumnName("Email");
        builder.Property(e => e.AuthenticatorType).HasColumnName("AuthenticatorType");
        builder.Property(e => e.Position).HasColumnName("Position");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}