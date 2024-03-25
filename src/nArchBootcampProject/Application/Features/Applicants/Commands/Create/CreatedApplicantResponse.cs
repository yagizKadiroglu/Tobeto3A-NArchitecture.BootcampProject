using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Security.Enums;

namespace Application.Features.Applicants.Commands.Create;

public class CreatedApplicantResponse : IResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Email { get; set; }
    public string About { get; set; }
}
