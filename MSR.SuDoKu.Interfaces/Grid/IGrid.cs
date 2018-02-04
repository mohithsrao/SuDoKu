using System.Collections.Generic;

namespace MSR.SuDoKu.Interfaces
{
    public interface IGrid
    {
        int Size { get; set; }
        IPoint Point { get; set; }
        ICell[,] Cells { get; set; }

        IEnumerable<ICell> GetRowAtIndex(int index);
        IEnumerable<ICell> GetColumnAtIndex(int index);
    }
}
