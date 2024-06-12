using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

namespace Persistence.EntityConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors");

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.CompanyName).HasColumnName("CompanyName");
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(x => x.Bootcamps);

        builder.HasData(_seeds);

    }

    public static Guid InstructorId { get; } = Guid.NewGuid();
    private IEnumerable<Instructor> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "Passw0rd!",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            Instructor instructorUser =
                new()
                {
                    Id = InstructorId,
                    Email = "memati@memati.com",
                    FirstName = "Memati",
                    LastName = "Baş",
                    Username = "memati",
                    NationalIdentity = "55555555555",
                    CompanyName = "Toros Holding",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
            yield return instructorUser;
        }
    }
}
