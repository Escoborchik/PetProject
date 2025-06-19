namespace PetProject.Domain.Shared
{
    public record class Error
    {
        public const string SEPARATOR = "|";
        private Error(string code, string message, ErrorType type, string? invalidFiled = null)
        {
            Code = code;
            Message = message;
            Type = type;
            InvalidFiled = invalidFiled;
        }

        public string Code { get; }
        public string Message { get; }
        public ErrorType Type { get; }
        public string? InvalidFiled { get; }        

        public static Error Validation(string code, string message, string? invalidFiled = null) 
            => new Error(code, message, ErrorType.Validation, invalidFiled);     
        
        public static Error NotFound(string code, string message) => new Error(code, message, ErrorType.NotFound);
        
        public static Error Failure(string code, string message) => new Error(code, message, ErrorType.Failure);        

        public static Error Conflict(string code, string message) => new Error(code, message, ErrorType.Conflict);

        public string Serialize()
        {
            return string.Join(SEPARATOR, Code, Message, Type);
        }

        public static Error Deserialize(string error)
        {
            var parts = error.Split(SEPARATOR);

            if (parts.Length < 3)
                throw new ArgumentException("Invalid serialized error!");

            if (!Enum.TryParse<ErrorType>(parts[2], out var type))
                throw new ArgumentException("Invalid serialized error!");

            return new Error(parts[0], parts[1], type);
        }

        public ErrorList ToErrorList() => new([this]);
    }

    public enum ErrorType
    {
        Validation,
        NotFound,
        Failure,
        Conflict
    }
}
