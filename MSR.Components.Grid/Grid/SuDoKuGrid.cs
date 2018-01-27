using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSR.Components.Grid.Grid
{
    public class SuDoKuGrid
    {
        public Grid[,] Grid { get; set; }

        public SuDoKuGrid(int gridSize)
        {
            Grid = CreateSuDoKuGrid(gridSize);
        }

        private Grid[,] CreateSuDoKuGrid(int gridSize)
        {
            var grid = new Grid[gridSize,gridSize];
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    grid[i, j] = new Grid(gridSize);
                }
            }
            return grid;
        }
    }
}
