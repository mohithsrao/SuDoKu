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
            IPoint point = new Point() { X = 0, Y = 0 };
            var grid = new Grid(size, point);

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
            IPoint point = new Point() { X = 0, Y = 0 };
            var grid = new Grid(size, point);

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
            IPoint point = new Point() { X = 0, Y = 0 };
            var resultList = new List<IValidationResult>();
            var cellList = new List<ICell>() {
                new Cell(0, 0,point) {Value = a },
                new Cell(0, 1,point) {Value = b },
                new Cell(1, 0,point) {Value = c },
                new Cell(1, 1,point) {Value = d },
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
            IPoint point = new Point() { X = 0, Y = 0 };
            var resultList = new List<IValidationResult>();
            var cellList = new List<ICell>() {
                new Cell(0, 0,point) {Value = a },
                new Cell(0, 1,point) {Value = b },
                new Cell(1, 0,point) {Value = c },
                new Cell(1, 1,point) {Value = d },
            };

            resultList.Add(validator.Validate(cellList.Skip(2)));
            resultList.Add(validator.Validate(cellList.Take(2)));

            var result = validator.ConsolidateValidations(resultList);

            Assert.IsTrue(result.IsValid);
        }

    }
}