using System.Collections.Generic;

namespace MSR.Components.Interface
{
    public interface IGrid
    {
        int Size { get; set; }
        IEnumerable<ICell[]> Rows { get; }
        IEnumerable<ICell[]> Columns { get; }
        ICell[,] Cells { get; set; }
    }
}
