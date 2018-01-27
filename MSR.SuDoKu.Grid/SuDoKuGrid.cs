
namespace MSR.SuDoKu.Grid
{
    public class SuDoKuGrid
    {
        public MSR.Components.Grid[,] Grid { get; set; }

        public int GridSize
        {
            get;

            set;
        }

        private int _gridSize;

        public SuDoKuGrid(int gridSize)
        {
            GridSize = gridSize;
            Grid = CreateSuDoKuGrid(gridSize);
        }

        private MSR.Components.Grid[,] CreateSuDoKuGrid(int gridSize)
        {
            var grid = new MSR.Components.Grid[gridSize, gridSize];
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    grid[i, j] = new MSR.Components.Grid(gridSize);
                }
            }
            return grid;
        }
    }
}
