using FluentValidation;

namespace Application.Features.Applications.Commands.Delete;

public class DeleteApplicationCommandValidator : AbstractValidator<DeleteApplicationCommand>
{
    public DeleteApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}