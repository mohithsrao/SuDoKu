namespace MSR.Component.Validators
{
    public interface IValidationResult
    {
        bool IsFilled { get; }
        bool HasRepetingValue { get; }
        bool IsValid { get; }
    }
}