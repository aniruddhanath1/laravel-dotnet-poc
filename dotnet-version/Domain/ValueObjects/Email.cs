namespace Domain.ValueObjects
{
    public record Email(string Value)
    {
        public static bool IsValid(string value) =>
            !string.IsNullOrWhiteSpace(value) && value.Contains("@");
    }
}
