using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Domain.Entities.Application>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Application> builder)
    {
        builder.ToTable("Applications").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.ApplicantId).HasColumnName("ApplicantId");
        builder.Property(a => a.BootcampId).HasColumnName("BootcampId");
        builder.Property(a => a.ApplicationStateId).HasColumnName("ApplicationStateId");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Applicant);
        builder.HasOne(x => x.ApplicationState);
        builder.HasOne(x => x.Bootcamp);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
