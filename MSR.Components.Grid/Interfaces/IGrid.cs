using MSR.Components.Grid.Cell;
using System.Collections.Generic;

namespace MSR.Components.Grid.Grid
{
    public interface IGrid
    {
        int Size { get; set; }
        IEnumerable<ICell[]> Rows { get; }
        IEnumerable<ICell[]> Columns { get; }
        ICell[,] Cells { get; set; }
    }
}
