using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MSR.Components.Grid.Grid.Tests
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
    }
}