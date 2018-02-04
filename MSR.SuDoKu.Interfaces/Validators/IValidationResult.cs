namespace MSR.SuDoKu.Interfaces
{
    public interface IValidationResult
    {
        bool IsFilled { get; }
        bool HasRepetingValue { get; }
        bool IsValid { get; }
    }
}