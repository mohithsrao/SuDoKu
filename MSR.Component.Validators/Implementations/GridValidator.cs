using System.Linq;
using System.Collections.Generic;
using MSR.SuDoKu.Interfaces;
using System;

namespace MSR.Component.Validators
{
    public class GridValidator : IValidator
    {
        public IValidationResult ConsolidateValidations(IEnumerable<IValidationResult> resultList)
        {
            var hasRepetingValue = resultList.Any(x => x.HasRepetingValue) ? true : false;
            var isFilled = resultList.All(x => x.IsFilled) ? true : false;

            return new ValidationResult(hasRepetingValue, isFilled);
        }

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
