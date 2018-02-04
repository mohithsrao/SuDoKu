
using MSR.Component.Validators;
using MSR.SuDoKu.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSR.SuDoKu.Grid
{
    public class SuDoKuGrid
    {
        #region Private Variables

        private IValidator validator;

        #endregion

        #region Public Properties

        public Components.Grid[,] Grid { get; set; }

        public int GridSize
        {
            get;

            set;
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
                    grid[i, j] = new Components.Grid(gridSize);
                }
            }
            return grid;
        }

        private IEnumerable<ICell> GetRowAtIndex(int index)
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

        private IEnumerable<ICell> GetColumnAtIndex(int index)
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

        #endregion

        #region Public Methods

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
            for (int i = 0; i < Math.Pow(GridSize, GridSize); i++)
            {
                resultList.Add(ValidateRow(i));
                resultList.Add(ValidateColumn(i));
            }

            return validator.ConsolidateValidations(resultList);
        }

        #endregion
    }
}
