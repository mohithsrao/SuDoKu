using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSR.Components;
using MSR.SuDoKu.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MSR.Component.Validators.Tests
{
    [TestClass()]
    public class GridValidatorsTests
    {
        private IValidator validator = null;

        [TestInitialize()]
        public void Init_GridValidatorsTests()
        {
            validator = new GridValidator();
        }

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

            var result = validator.Validate(grid.Cells.Cast<ICell>());

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        [DataRow(1, 2, 1, 1)]
        [DataRow(1, 2, null, 4)]
        [DataRow(1, null, 3, 4)]
        public void ConsolidateValidations_negative(int? a, int? b, int? c, int? d)
        {
            var resultList = new List<IValidationResult>();
            var cellList = new List<ICell>() {
                new Cell(0, 0) {Value = a },
                new Cell(0, 1) {Value = b },
                new Cell(1, 0) {Value = c },
                new Cell(1, 1) {Value = d },
            };

            resultList.Add(validator.Validate(cellList.Skip(2)));
            resultList.Add(validator.Validate(cellList.Take(2)));

            var result = validator.ConsolidateValidations(resultList);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod()]
        [DataRow(1, 2, 3, 4)]
        [DataRow(2, 3, 4, 1)]
        [DataRow(3, 4, 1, 2)]
        [DataRow(4, 1, 2, 3)]
        public void ConsolidateValidations(int? a, int? b, int? c, int? d)
        {
            var resultList = new List<IValidationResult>();
            var cellList = new List<ICell>() {
                new Cell(0, 0) {Value = a },
                new Cell(0, 1) {Value = b },
                new Cell(1, 0) {Value = c },
                new Cell(1, 1) {Value = d },
            };

            resultList.Add(validator.Validate(cellList.Skip(2)));
            resultList.Add(validator.Validate(cellList.Take(2)));

            var result = validator.ConsolidateValidations(resultList);

            Assert.IsTrue(result.IsValid);
        }

    }
}