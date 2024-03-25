using FluentValidation;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
{
    public CreateInstructorCommandValidator()
    {
        RuleFor(c => c.Username).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.DateOfBirth).NotEmpty();
        RuleFor(c => c.NationalIdentity).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.AuthenticatorType).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
    }
}
