using FluentValidation.Results;

namespace Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new List<string>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        foreach (ValidationFailure failure in failures) Errors.Add(failure.ErrorMessage);
    }

    public ValidationException(params string[] errors)
    {
        Errors = new List<string>(errors);
    }

    public List<string> Errors { get; }
}