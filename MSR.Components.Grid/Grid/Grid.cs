using MSR.Component.Validators;
using MSR.SuDoKu.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MSR.Components
{
    public class Grid : IGrid
    {
        #region Private Variables

        private IValidator validator;

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

        #endregion

        public Grid(int dimention)
        {
            Size = dimention;
            Cells = CreateGrid(dimention);
            /*
            Rows = Cells
                .Cast<ICell>()
                .GroupBy(x => x.X_Cord)
                .Select(x => x.ToArray());
            Columns = Cells
                .Cast<ICell>()
                .GroupBy(x => x.Y_Cord)
                .Select(x => x.ToArray());
            */
            validator = new GridValidator();
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

        public IValidationResult ValidateRow(int index)
        {
            var rowAtIndex = GetRowAtIndex(index);
            return validator.Validate(rowAtIndex);
        }

        public IValidationResult ValidateColumn(int index)
        {
            var columnAtIndex = GetColumnAtIndex(index);
            return validator.Validate(columnAtIndex);
        }

        public IEnumerable<ICell> GetRowAtIndex(int index)
        {
            return Cells.Cast<ICell>().Where(x => x.X_Cord == index);
        }

        public IEnumerable<ICell> GetColumnAtIndex(int index)
        {
            return Cells.Cast<ICell>().Where(x => x.Y_Cord == index);
        }

        public IValidationResult ValidateGrid()
        {
            return validator.Validate(Cells.Cast<ICell>());
        }

        #endregion

        #region Private Methods

        private ICell[,] CreateGrid(int dimention)
        {
            var cells = new Cell[dimention, dimention];
            for (int i = 0; i < dimention; i++)
            {
                for (int j = 0; j < dimention; j++)
                {
                    cells[i, j] = new Cell(i, j);
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
