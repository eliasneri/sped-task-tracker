using FluentValidation;
using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Validators;

public class CreateTaskItemValidator : AbstractValidator<CreateTaskItemDto>
{
    public CreateTaskItemValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MinimumLength(3).WithMessage("Title must have at least 3 characters")
            .MaximumLength(200).WithMessage("Title must have at least 200 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MinimumLength(5).WithMessage("Title must have at least 5 characters");
    }
}