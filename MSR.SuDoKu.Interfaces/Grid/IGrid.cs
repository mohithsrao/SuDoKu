using System.Collections.Generic;

namespace MSR.SuDoKu.Interfaces
{
    public interface IGrid
    {
        int Size { get; set; }
        ICell[,] Cells { get; set; }
    }
}
