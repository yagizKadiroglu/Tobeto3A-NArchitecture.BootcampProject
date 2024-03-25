using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Enums;

namespace Domain.Entities;

public class Applicant : User
{
    public string About { get; set; }

    public ICollection<Application> Applications { get; set; }
    public BlackList BlackList { get; set; }

    public Applicant()
    {
        Applications = new HashSet<Application>();
    }

    public Applicant(
        Guid id,
        string username,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string nationalIdentity,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt,
        string about,
        AuthenticatorType authenticatorType
    )
        : this()
    {
        Id = id;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        AuthenticatorType = authenticatorType;
        About = about;
    }
}
