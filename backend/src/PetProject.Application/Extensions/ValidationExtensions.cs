using FluentValidation.Results;
using PetProject.Domain.Shared;


namespace PetProject.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static ErrorList ToErrorList(this ValidationResult validationResult)
        {
            var validationErrors = validationResult.Errors;
            var errors = new List<Error>();

            foreach (var validationError in validationErrors)
            {
                var error = Error.Deserialize(validationError.ErrorMessage);
                errors.Add(Error.Validation(error.Code, error.Message, validationError.PropertyName));
            }

            return errors;
        }
    }
}
