namespace PetProject.Domain.Shared
{
    public static class Errors
    {
        public static class General
        {
            public static Error ValueIsInvalid(string? name = null)
            {
                var label = name ?? "value";

                return Error.Validation("value.is.invalid", $"{label} is invalid");
            }

            public static Error NotFound(Guid? id = null)
            {
                var forId = id is null ? "" : $" for Id '{id}'";

                return Error.NotFound("record.not.found", $"record not found{forId}");
            }

            public static Error AlreadyExist(string? name = null)
            {
                return Error.Validation("record.already.exist", $"{name} already exist");
            }
        }        
    }
}
