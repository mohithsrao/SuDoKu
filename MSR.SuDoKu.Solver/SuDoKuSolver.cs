using MSR.SuDoKu.Grid;
using MSR.SuDoKu.Interfaces;
using MSR.SuDoKu.Interfaces.Grid;
using System.Collections.Generic;
using System.Linq;

namespace MSR.SuDoKu.Solver
{
    public class SuDoKuSolver
    {
        private SuDoKuGridCreator creator = null;
        private ISuDoKuGrid Grid = null;

        public SuDoKuSolver()
        {
            creator = new SuDoKuGridCreator();
        }

        public bool Solve(int size, out ISuDoKuGrid grid, IEnumerable<int?> intList)
        {
            Grid = creator.Create(size, intList.ToArray());
            IEnumerable<ICell> emptyCellList = GetEmptyCellList();

            AssignValueToGrid(size, emptyCellList);

            grid = Grid;

            return Grid.Validate().IsValid;
        }

        private IEnumerable<ICell> GetEmptyCellList()
        {
            var allCells = Grid.Grid.Cast<IGrid>().SelectMany(x => x.Cells.Cast<ICell>());
            // Find All Empty Cells
            var emptyCellList = allCells.Where(x => x.Value == null);
            return emptyCellList;
        }

        private void AssignValueToGrid(int size, IEnumerable<ICell> emptyCellList)
        {
            if (emptyCellList.Count() == 0)
            {
                return;
            }

            //Get All Possible Values for cell
            var allPossibleValuesForGrid = Enumerable.Range(1, size * size);

            //Generate possible values for empty cells
            var possibleCellValuesList = new Dictionary<ICell, IEnumerable<int>>();
            for (int i = 0; i < emptyCellList.Count(); i++)
            {
                var cell = emptyCellList.ElementAt(i);

                var globalY = (cell.ParentPoint.Y * size) + cell.Point.Y;
                var globalX = (cell.ParentPoint.X * size) + cell.Point.X;

                var rowList = Grid
                    .GetRowAtIndex(globalX)
                    .Where(x => x.Value.HasValue)
                    .Select(x => x.Value.Value);
                var columnList = Grid
                    .GetColumnAtIndex(globalY)
                    .Where(x => x.Value.HasValue)
                    .Select(x => x.Value.Value);
                var gridList = Grid
                    .Grid[cell.ParentPoint.X, cell.ParentPoint.Y]
                    .Cells.Cast<ICell>()
                    .Where(x => x.Value.HasValue)
                    .Select(x => x.Value.Value);

                var possibleValueList = allPossibleValuesForGrid
                    .Except(rowList)
                    .Except(columnList)
                    .Except(gridList);

                possibleCellValuesList.Add(cell, possibleValueList);
            }

            // Select one cell and populate value
            if (possibleCellValuesList.Any(x => x.Value.Count() == 1))
            {
                var cellValue = possibleCellValuesList.Where(x => x.Value.Count() == 1).First();
                cellValue.Key.Value = cellValue.Value.First();
            }

            var cellListRemaining = GetEmptyCellList();

            AssignValueToGrid(size, cellListRemaining);
        }
    }
}
