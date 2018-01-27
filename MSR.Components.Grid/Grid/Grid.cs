using System;
using MSR.Components.Grid.Cell;
using System.Collections.Generic;
using System.Linq;

namespace MSR.Components.Grid.Grid
{
    public class Grid : IGrid
    {
        #region Private Variables

        #endregion

        #region Public Properties

        public int Size
        {
            get;

            set;
        }
        public ICell[,] Cells
        {
            get;

            set;
        }

        public IEnumerable<ICell[]> Rows
        {
            get; set;
        }

        public IEnumerable<ICell[]> Columns
        {
            get; set;
        }

        #endregion

        public Grid(int dimention)
        {
            Size = dimention;
            Cells = CreateGrid(dimention);
            Rows = Cells
                .Cast<ICell>()
                .GroupBy(x => x.X_Cord)
                .Select(x => x.ToArray());
            Columns = Cells
                .Cast<ICell>()
                .GroupBy(x => x.Y_Cord)
                .Select(x => x.ToArray());
        }

        #region Public Methods

        public ICell this[int index]
        {
            get
            {
                var x = GetXCord(index);
                var y = GetYCord(index);
                return Cells[x, y];
            }
        }

        public void SetValueToCell(int index, int value)
        {
            SetValueToCell(GetXCord(index), GetYCord(index), value);
        }

        public void SetValueToCell(int x, int y, int value)
        {
            Cells[x, y].Value = value;
        }

        #endregion

        #region Privatte Methods

        private ICell[,] CreateGrid(int dimention)
        {
            var cells = new Cell.Cell[dimention, dimention];
            for (int i = 0; i < dimention; i++)
            {
                for (int j = 0; j < dimention; j++)
                {
                    cells[i, j] = new Cell.Cell(i, j);
                }
            }
            return cells;
        }

        private int GetXCord(int index)
        {
            return index / Size;
        }

        private int GetYCord(int index)
        {
            return index % Size;
        }

        #endregion

    }
}
