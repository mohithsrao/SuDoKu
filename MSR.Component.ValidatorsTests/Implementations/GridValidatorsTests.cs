using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSR.Components.Interface;
using System.Linq;

namespace MSR.Component.Validators.Tests
{
    [TestClass()]
    public class GridValidatorsTests
    {
        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void ValidateGridTest(int size)
        {
            var grid = new Components.Grid(size);

            var valueCount = 1;
            foreach (var cell in grid.Cells)
            {
                cell.Value = valueCount;
                valueCount++;
            }
            var validator = new GridValidator();

            var result = validator.Validate(grid.Cells.Cast<ICell>());

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod()]
        [DataRow(2)]
        [DataRow(3)]
        public void ValidateGrid_Negative_Test(int size)
        {
            var grid = new Components.Grid(size);

            var valueCount = 1;
            foreach (var cell in grid.Cells)
            {
                cell.Value = valueCount;
            }
            var validator = new GridValidator();

            var result = validator.Validate(grid.Cells.Cast<ICell>());

            Assert.IsFalse(result.IsValid);
        }
    }
}