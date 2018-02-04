using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSR.Components;
using MSR.SuDoKu.Interfaces;
using System;

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
        public void FillSuDoKuGrid()
        {
            IPoint point00 = new Point() { X = 0, Y = 0 };
            IPoint point01 = new Point() { X = 0, Y = 1 };
            IPoint point10 = new Point() { X = 1, Y = 0 };
            IPoint point11 = new Point() { X = 1, Y = 1 };
            var grid0 = new Components.Grid(2, point00);
            grid0.Cells[0, 0].Value = 1;
            grid0.Cells[0, 1].Value = 2;
            grid0.Cells[1, 0].Value = 3;
            grid0.Cells[1, 1].Value = 4;
            var grid1 = new Components.Grid(2, point01);
            grid1.Cells[0, 0].Value = 1;
            grid1.Cells[0, 1].Value = 2;
            grid1.Cells[1, 0].Value = 3;
            grid1.Cells[1, 1].Value = 4;
            var grid2 = new Components.Grid(2, point10);
            grid2.Cells[0, 0].Value = 1;
            grid2.Cells[0, 1].Value = 2;
            grid2.Cells[1, 0].Value = 3;
            grid2.Cells[1, 1].Value = 4;
            var grid3 = new Components.Grid(2, point11);
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
                    if (cell.Point.X == 0 && cell.Point.Y == 0)
                    {
                        Assert.AreEqual(1, cell.Value);
                    }
                    if (cell.Point.X == 0 && cell.Point.Y == 1)
                    {
                        Assert.AreEqual(2, cell.Value);
                    }
                    if (cell.Point.X == 1 && cell.Point.Y == 0)
                    {
                        Assert.AreEqual(3, cell.Value);
                    }
                    if (cell.Point.X == 1 && cell.Point.Y == 1)
                    {
                        Assert.AreEqual(4, cell.Value);
                    }
                }
            }
        }

        [TestMethod()]
        public void ValidateSuDoKuGrid()
        {
            /*            
            1   2   3   4
            3   4   1   2 
            2   1   4   3
            4   3   2   1
             * */
            IPoint point00 = new Point() { X = 0, Y = 0 };
            IPoint point01 = new Point() { X = 0, Y = 1 };
            IPoint point10 = new Point() { X = 1, Y = 0 };
            IPoint point11 = new Point() { X = 1, Y = 1 };
            var size = 2;
            var grid0 = new Components.Grid(size, point00);
            grid0.SetValueToCell(0, 1);
            grid0.SetValueToCell(1, 2);
            grid0.SetValueToCell(2, 3);
            grid0.SetValueToCell(3, 4);
            var grid1 = new Components.Grid(size, point01);
            grid1.SetValueToCell(0, 3);
            grid1.SetValueToCell(1, 4);
            grid1.SetValueToCell(2, 1);
            grid1.SetValueToCell(3, 2);
            var grid2 = new Components.Grid(size, point10);
            grid2.SetValueToCell(0, 2);
            grid2.SetValueToCell(1, 1);
            grid2.SetValueToCell(2, 4);
            grid2.SetValueToCell(3, 3);
            var grid3 = new Components.Grid(size, point11);
            grid3.SetValueToCell(0, 4);
            grid3.SetValueToCell(1, 3);
            grid3.SetValueToCell(2, 2);
            grid3.SetValueToCell(3, 1);

            var sGrid = new SuDoKuGrid(size);
            sGrid.Grid[0, 0] = grid0;
            sGrid.Grid[0, 1] = grid1;
            sGrid.Grid[1, 0] = grid2;
            sGrid.Grid[1, 1] = grid3;

            Assert.IsTrue(sGrid.ValidateRow(0).IsValid);
            Assert.IsTrue(sGrid.ValidateRow(1).IsValid);
            Assert.IsTrue(sGrid.ValidateRow(2).IsValid);
            Assert.IsTrue(sGrid.ValidateRow(3).IsValid);

            Assert.IsTrue(sGrid.ValidateColumn(0).IsValid);
            Assert.IsTrue(sGrid.ValidateColumn(1).IsValid);
            Assert.IsTrue(sGrid.ValidateColumn(2).IsValid);
            Assert.IsTrue(sGrid.ValidateColumn(3).IsValid);

            Assert.IsTrue(sGrid.Validate().IsValid);
        }

        [TestMethod()]
        public void ValidateSuDoKuGrid_negative()
        {
            /*            
            1   2   1   2
            2   1   3   4 
            1   3   4   1
            3   4   2   1
             * */
            IPoint point00 = new Point() { X = 0, Y = 0 };
            IPoint point01 = new Point() { X = 0, Y = 1 };
            IPoint point10 = new Point() { X = 1, Y = 0 };
            IPoint point11 = new Point() { X = 1, Y = 1 };
            var size = 2;
            var grid0 = new Components.Grid(size, point00);
            grid0.SetValueToCell(0, 1);
            grid0.SetValueToCell(1, 2);
            grid0.SetValueToCell(2, 2);
            grid0.SetValueToCell(3, 1);
            var grid1 = new Components.Grid(size, point01);
            grid1.SetValueToCell(0, 1);
            grid1.SetValueToCell(1, 2);
            grid1.SetValueToCell(2, 3);
            grid1.SetValueToCell(3, 4);
            var grid2 = new Components.Grid(size, point10);
            grid2.SetValueToCell(0, 1);
            grid2.SetValueToCell(1, 3);
            grid2.SetValueToCell(2, 3);
            grid2.SetValueToCell(3, 4);
            var grid3 = new Components.Grid(size, point11);
            grid3.SetValueToCell(0, 4);
            grid3.SetValueToCell(1, 1);
            grid3.SetValueToCell(2, 2);
            grid3.SetValueToCell(3, 1);

            var sGrid = new SuDoKuGrid(size);
            sGrid.Grid[0, 0] = grid0;
            sGrid.Grid[0, 1] = grid1;
            sGrid.Grid[1, 0] = grid2;
            sGrid.Grid[1, 1] = grid3;

            Assert.IsFalse(sGrid.ValidateRow(0).IsValid);
            Assert.IsTrue(sGrid.ValidateRow(1).IsValid);
            Assert.IsFalse(sGrid.ValidateRow(2).IsValid);
            Assert.IsTrue(sGrid.ValidateRow(3).IsValid);

            Assert.IsFalse(sGrid.ValidateColumn(0).IsValid);
            Assert.IsTrue(sGrid.ValidateColumn(1).IsValid);
            Assert.IsTrue(sGrid.ValidateColumn(2).IsValid);
            Assert.IsFalse(sGrid.ValidateColumn(3).IsValid);

            var result = sGrid.Validate();

            Assert.IsFalse(result.IsValid);
        }
    }
}