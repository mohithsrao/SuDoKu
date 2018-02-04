using System.Collections.Generic;

namespace MSR.SuDoKu.Interfaces
{
    public interface IValidator
    {
        IValidationResult Validate(IEnumerable<ICell> grid);
        IValidationResult ConsolidateValidations(IEnumerable<IValidationResult> resultList);
    }
}