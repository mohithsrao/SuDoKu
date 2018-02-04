using System.Collections.Generic;

namespace MSR.SuDoKu.Interfaces.Grid
{
    public interface ISuDoKuGrid
    {
        IGrid[,] Grid { get; set; }
        int GridSize { get; }

        IValidationResult Validate();
        IValidationResult ValidateColumn(int index);
        IValidationResult ValidateRow(int index);

        IEnumerable<ICell> GetRowAtIndex(int index);
        IEnumerable<ICell> GetColumnAtIndex(int index);
    }
}
