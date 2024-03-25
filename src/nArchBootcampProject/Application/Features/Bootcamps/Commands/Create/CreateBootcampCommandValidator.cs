using FluentValidation;

namespace Application.Features.Bootcamps.Commands.Create;

public class CreateBootcampCommandValidator : AbstractValidator<CreateBootcampCommand>
{
    public CreateBootcampCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.BootcampStateId).NotEmpty();
        RuleFor(c => c.StarDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
    }
}
