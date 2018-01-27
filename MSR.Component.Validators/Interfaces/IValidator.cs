using MSR.Components.Interface;
using System.Collections.Generic;

namespace MSR.Component.Validators
{
    public interface IValidator
    {
        IValidationResult Validate(IEnumerable<ICell> grid);
    }
}