using FluentValidation;
using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Validators;

public class UpdateTaskItemValidator : AbstractValidator<UpdateTaskItemDto>
{
    public UpdateTaskItemValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MinimumLength(5).WithMessage("Title must have at least 5 characters");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required");
    }
}