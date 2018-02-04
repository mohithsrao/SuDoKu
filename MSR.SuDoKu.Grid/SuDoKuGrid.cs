
using MSR.Component.Validators;
using MSR.Components;
using MSR.SuDoKu.Interfaces;
using MSR.SuDoKu.Interfaces.Grid;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSR.SuDoKu.Grid
{
    public class SuDoKuGrid : ISuDoKuGrid
    {
        #region Private Variables

        private IValidator validator;

        #endregion

        #region Public Properties

        public IGrid[,] Grid { get; set; }

        public int GridSize
        {
            get;
        }

        #endregion


        public SuDoKuGrid(int gridSize)
        {
            GridSize = gridSize;
            Grid = CreateSuDoKuGrid(gridSize);
            validator = new GridValidator();
        }

        #region Private Methods

        private Components.Grid[,] CreateSuDoKuGrid(int gridSize)
        {
            var grid = new Components.Grid[gridSize, gridSize];
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    IPoint point = new Point() { X = i, Y = j };
                    grid[i, j] = new Components.Grid(gridSize, point);
                }
            }
            return grid;
        }

        #endregion

        #region Public Methods

        public IEnumerable<ICell> GetRowAtIndex(int index)
        {
            var gridLocation = index / GridSize;
            var rowLocation = index % GridSize;

            var rowList = new List<ICell>();
            for (int i = 0; i < GridSize; i++)
            {
                rowList.AddRange(Grid[gridLocation, i].GetRowAtIndex(rowLocation));
            }
            return rowList;
        }

        public IEnumerable<ICell> GetColumnAtIndex(int index)
        {
            var gridLocation = index / GridSize;
            var rowLocation = index % GridSize;

            var rowList = new List<ICell>();
            for (int i = 0; i < GridSize; i++)
            {
                rowList.AddRange(Grid[i, gridLocation].GetColumnAtIndex(rowLocation));
            }
            return rowList;
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

        public IValidationResult Validate()
        {
            var resultList = new List<IValidationResult>();
            // Validate Grid Data
            foreach (var grid in Grid.Cast<Components.Grid>())
            {
                resultList.Add(grid.ValidateGrid());
            }

            // Validate Grid and Row Data
            for (int i = 0; i < GridSize * GridSize; i++)
            {
                resultList.Add(ValidateRow(i));
                resultList.Add(ValidateColumn(i));
            }

            return validator.ConsolidateValidations(resultList);
        }

        #endregion
    }
}
