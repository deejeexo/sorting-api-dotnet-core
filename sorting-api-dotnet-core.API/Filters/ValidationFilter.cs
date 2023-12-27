using FluentValidation;

namespace sorting_api_dotnet_core.API;

public class ValidationFilter<T>(IValidator<T> validator) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next
    )
    {
        if (context.Arguments.FirstOrDefault(x => x?.GetType() == typeof(T)) is not T argument)
        {
            return Results.BadRequest("Unable to find parameters or body for validation");
        }

        var validationResult = await validator.ValidateAsync(argument!);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var result = await next(context);
        return result!;
    }
}
