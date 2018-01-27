using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSR.Components.Grid.Cell;

namespace MSR.Components.Grid.Grid
{
    public class Grid : AbstractGrid
    {
        public Grid(int dimention) : base(dimention)
        {
            Cells = CreateGrid(dimention);
        }

        private AbstractCell[,] CreateGrid(int dimention)
        {
            var cells = new EmptyCell[dimention, dimention];
            for (int i = 0; i < dimention; i++)
            {
                for (int j = 0; j < dimention; j++)
                {
                    cells[i, j] = new EmptyCell(i, j);
                }
            }
            return cells;
        }

        public override AbstractCell[,] Cells
        {
            get;
            set;
        }
    }
}
