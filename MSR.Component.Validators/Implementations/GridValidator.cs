using System.Linq;
using System.Collections.Generic;
using MSR.Components.Interface;

namespace MSR.Component.Validators
{
    public class GridValidator : IValidator
    {
        public IValidationResult Validate(IEnumerable<ICell> cells)
        {
            var isFilled = false;
            var hasRepetingValue = false;

            isFilled = cells.Count(x => x.Value == null) == 0;

            var notNullCells = cells.Where(x => x.Value != null);
            var groupNotNullCells = notNullCells.GroupBy(x => x.Value);
            hasRepetingValue = groupNotNullCells.Any(x => x.Count() > 1);

            return new ValidationResult(hasRepetingValue, isFilled);
        }
    }
}
