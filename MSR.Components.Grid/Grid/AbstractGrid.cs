using MSR.Components.Grid.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSR.Components.Grid.Grid
{
    public abstract class AbstractGrid
    {
        public abstract AbstractCell[,] Cells { get; set; }

        public AbstractGrid(int dimention)
        {
        }
    }
}
