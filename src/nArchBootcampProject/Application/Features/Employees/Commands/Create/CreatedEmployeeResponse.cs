using NArchitecture.Core.Application.Responses;

namespace Application.Features.Employees.Commands.Create;

public class CreatedEmployeeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Email { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }
    public string Position { get; set; }
}