namespace MSR.Component.Validators
{
    internal class ValidationResult : IValidationResult
    {
        public ValidationResult(bool hasRepetingValue, bool isFilled)
        {
            IsFilled = isFilled;
            HasRepetingValue = hasRepetingValue;
        }

        public bool IsFilled
        {
            get;
            private set;
        }

        public bool HasRepetingValue
        {
            get;
            private set;
        }

        public bool IsValid
        {
            get
            {
                return IsFilled && !HasRepetingValue;
            }
        }
    }
}