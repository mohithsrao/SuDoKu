using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MSR.Components.Grid.Grid.Tests
{
    [TestClass()]
    public class GridTests
    {
        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void GridInitTest(int size)
        {
            //Arrange
            var cellLength = Math.Pow(size, 2);
            //Act
            var grid = new Grid(size);

            //Assert
            Assert.AreEqual(cellLength, grid.Cells.Length);
        }

        [TestMethod()]
        [DataRow(1, 0, 0, 0)]
        [DataRow(2, 0, 0, 1)]
        [DataRow(2, 0, 1, 2)]
        [DataRow(2, 1, 0, 3)]
        [DataRow(2, 1, 1, 4)]
        [DataRow(3, 0, 0, 5)]
        [DataRow(3, 0, 1, 6)]
        [DataRow(3, 0, 2, 7)]
        [DataRow(3, 1, 0, 8)]
        [DataRow(3, 1, 1, 9)]
        [DataRow(3, 1, 2, 10)]
        [DataRow(3, 2, 0, 11)]
        [DataRow(3, 2, 1, 12)]
        [DataRow(3, 2, 2, 13)]
        public void SetGridValueTest(int size, int x, int y, int value)
        {
            var grid = new Grid(size);

            grid.SetValueToCell(x, y, value);

            Assert.AreEqual(value, grid.Cells[x, y].Value);
        }

        [TestMethod()]
        [DataRow(1, 0, 0)]
        [DataRow(2, 0, 1)]
        [DataRow(2, 1, 2)]
        [DataRow(2, 2, 3)]
        [DataRow(2, 3, 4)]
        [DataRow(3, 0, 5)]
        [DataRow(3, 1, 6)]
        [DataRow(3, 2, 7)]
        [DataRow(3, 3, 8)]
        [DataRow(3, 4, 9)]
        [DataRow(3, 5, 10)]
        [DataRow(3, 6, 11)]
        [DataRow(3, 7, 12)]
        [DataRow(3, 8, 13)]
        public void SetGridValueByIndexerTest(int size, int index, int value)
        {
            var grid = new Grid(size);

            grid.SetValueToCell(index, value);

            Assert.AreEqual(value, grid[index].Value);
        }
    }
}