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