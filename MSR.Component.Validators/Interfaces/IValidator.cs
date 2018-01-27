using MSR.Components.Grid.Cell;
using MSR.Components.Grid.Grid;
using System.Collections.Generic;

namespace MSR.Component.Validators
{
    public interface IValidator
    {
        IValidationResult Validate(IEnumerable<ICell> grid);
    }
}