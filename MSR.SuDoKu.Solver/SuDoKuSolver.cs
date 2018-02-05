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

            // Select cell which has only one entry available
            foreach (var grid in Grid.Grid)
            {
                var gridCells = grid.Cells.Cast<ICell>()
                                    .Where(y => !y.Value.HasValue);
                var list = possibleCellValuesList.Join(gridCells,
                   s => s.Key,
                   q => q,
                   (s, q) => s);

                if (list.Any(x => x.Value.Count() == 1))
                {
                    var cellData = list
                                    .Where(x => x.Value.Count() == 1)
                                    .Select(x => x.Key)
                                    .FirstOrDefault();
                    cellData.Value = list
                                        .FirstOrDefault(x => x.Value.Count() == 1)
                                        .Value
                                        .FirstOrDefault();
                    break;
                }

                var uniqueKeyList = list
                                .SelectMany(x => x.Value)
                                .GroupBy(x => x)
                                .Where(x => x.Count() == 1)
                                .Select(x => x.Key);

                if (uniqueKeyList.Count() > 0)
                {
                    var cellData = list.Where(x => x.Value.Contains(uniqueKeyList.First())).FirstOrDefault();
                    cellData.Key.Value = uniqueKeyList.FirstOrDefault();
                    break;
                }
            }

            //if (possibleCellValuesList.Any(x => x.Value.Count() == 1))
            //{
            //    var cellValue = possibleCellValuesList.Where(x => x.Value.Count() == 1).First();
            //    cellValue.Key.Value = cellValue.Value.First();
            //}
            //else if (possibleCellValuesList.Any(x => x.Value.Count() == 2))
            //{
            //    var cellValue = possibleCellValuesList.Where(x => x.Value.Count() == 2).First();
            //    cellValue.Key.Value = cellValue.Value.First();
            //}

            var cellListRemaining = GetEmptyCellList();

            AssignValueToGrid(size, cellListRemaining);
        }
    }
}
