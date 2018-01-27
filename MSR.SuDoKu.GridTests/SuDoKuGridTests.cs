using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSR.SuDoKu.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSR.SuDoKu.Grid.Tests
{
    [TestClass()]
    public class SuDoKuGridTests
    {
        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void SuDoKuGridTest(int size)
        {
            //Arrange
            var cellLength = Math.Pow(size, 2);

            //Act
            var sGrid = new SuDoKuGrid(size);

            //Assert
            Assert.AreEqual(cellLength, sGrid.Grid.Length);
            foreach (var grid in sGrid.Grid)
            {
                Assert.AreEqual(cellLength, grid.Cells.Length);
            }
        }

        [TestMethod()]
        public void ValidateSuDoKuGrid()
        {
            var grid0 = new Components.Grid(2);
            grid0.Cells[0, 0].Value = 1;
            grid0.Cells[0, 1].Value = 2;
            grid0.Cells[1, 0].Value = 3;
            grid0.Cells[1, 1].Value = 4;
            var grid1 = new Components.Grid(2);
            grid1.Cells[0, 0].Value = 1;
            grid1.Cells[0, 1].Value = 2;
            grid1.Cells[1, 0].Value = 3;
            grid1.Cells[1, 1].Value = 4;
            var grid2 = new Components.Grid(2);
            grid2.Cells[0, 0].Value = 1;
            grid2.Cells[0, 1].Value = 2;
            grid2.Cells[1, 0].Value = 3;
            grid2.Cells[1, 1].Value = 4;
            var grid3 = new Components.Grid(2);
            grid3.Cells[0, 0].Value = 1;
            grid3.Cells[0, 1].Value = 2;
            grid3.Cells[1, 0].Value = 3;
            grid3.Cells[1, 1].Value = 4;

            var sGrid = new SuDoKuGrid(2);
            sGrid.Grid[0, 0] = grid0;
            sGrid.Grid[0, 1] = grid1;
            sGrid.Grid[1, 0] = grid2;
            sGrid.Grid[1, 1] = grid3;

            foreach (var grid in sGrid.Grid)
            {
                foreach (var cell in grid.Cells)
                {
                    if (cell.X_Cord == 0 && cell.Y_Cord == 0)
                    {
                        Assert.AreEqual(1, cell.Value);
                    }
                    if (cell.X_Cord == 0 && cell.Y_Cord == 1)
                    {
                        Assert.AreEqual(2, cell.Value);
                    }
                    if (cell.X_Cord == 1 && cell.Y_Cord == 0)
                    {
                        Assert.AreEqual(3, cell.Value);
                    }
                    if (cell.X_Cord == 1 && cell.Y_Cord == 1)
                    {
                        Assert.AreEqual(4, cell.Value);
                    }
                }
            }
        }

    }
}