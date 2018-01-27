using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSR.Components.Grid.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}