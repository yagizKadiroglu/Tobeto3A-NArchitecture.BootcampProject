using FluentValidation;

namespace Application.Features.Applicants.Commands.Create;

public class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
{
    public CreateApplicantCommandValidator()
    {
        RuleFor(c => c.Username).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.DateOfBirth).NotEmpty();
        RuleFor(c => c.NationalIdentity).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.About).NotEmpty();
    }
}
