using FluentValidation;

namespace sorting_api_dotnet_core.API;

public class SortValidator : AbstractValidator<SortRequest>
{
    public SortValidator()
    {
        RuleFor(x => x.Items)
            .NotNull()
            .WithMessage("Items cannot be null.")
            .NotEmpty()
            .WithMessage("Items cannot be empty.")
            .Must(items => items.Count >= 2)
            .WithMessage("Items must contain at least 2 elements.")
            .Must(items => items.All(item => item >= 0 && item <= 10))
            .WithMessage("Items must be between 0 and 10.");

        RuleFor(x => x.Algorithm)
            .NotNull()
            .WithMessage("Algorithm cannot be null.")
            .IsInEnum()
            .WithMessage("This algorithm is not supported.");
    }
}
