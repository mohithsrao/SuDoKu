using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSR.SuDoKu.Grid;
using System.Collections.Generic;

namespace MSR.SuDoKu.GridTests
{
    [TestClass]
    public class SuDoKuCreatorTests
    {
        private SuDoKuGridCreator creator = null;

        [TestInitialize()]
        public void InitCreator()
        {
            creator = new SuDoKuGridCreator();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongCreatorData()
        {
            var list = new List<int?>();
            var sgrid = creator.Create(2, list.ToArray());
        }

        [TestMethod]
        public void CreateTest_2x2()
        {
            /*
             2  4   *   *
             1  *   2   *
             4  1   *   *
             *  2   4   *
             */
            var list = new List<int?>() {
                2,4,null,null,
                1,null,2,null,
                4,1,null,null,
                null,2,4,null,
            };
            var sgrid = creator.Create(2, list.ToArray());

            Assert.AreEqual(sgrid.Grid[0, 0].Cells[0, 0].Value, list[0], "0");
            Assert.AreEqual(sgrid.Grid[0, 0].Cells[0, 1].Value, list[1], "1");
            Assert.AreEqual(sgrid.Grid[0, 1].Cells[0, 0].Value, list[2], "2");
            Assert.AreEqual(sgrid.Grid[0, 1].Cells[0, 1].Value, list[3], "3");
            Assert.AreEqual(sgrid.Grid[0, 0].Cells[1, 0].Value, list[4], "4");
            Assert.AreEqual(sgrid.Grid[0, 0].Cells[1, 1].Value, list[5], "5");
            Assert.AreEqual(sgrid.Grid[0, 1].Cells[1, 0].Value, list[6], "6");
            Assert.AreEqual(sgrid.Grid[0, 1].Cells[1, 1].Value, list[7], "7");
            Assert.AreEqual(sgrid.Grid[1, 0].Cells[0, 0].Value, list[8], "8");
            Assert.AreEqual(sgrid.Grid[1, 0].Cells[0, 1].Value, list[9], "9");
            Assert.AreEqual(sgrid.Grid[1, 1].Cells[0, 0].Value, list[10], "10");
            Assert.AreEqual(sgrid.Grid[1, 1].Cells[0, 1].Value, list[11], "11");
            Assert.AreEqual(sgrid.Grid[1, 0].Cells[1, 0].Value, list[12], "12");
            Assert.AreEqual(sgrid.Grid[1, 0].Cells[1, 1].Value, list[13], "13");
            Assert.AreEqual(sgrid.Grid[1, 1].Cells[1, 0].Value, list[14], "14");
            Assert.AreEqual(sgrid.Grid[1, 1].Cells[1, 1].Value, list[15], "15");
        }

        [TestMethod]
        public void CreateTest_3x3()
        {
            var list = new List<int?>() {

               null,2,null ,null,5,3 ,7,4,8,
               null,5,null ,1,null,6 ,null,2,null,
               9,3,7 ,2,8,4 ,0,1,6,

               5,null,3 ,8,null,2 ,1,6,4,
               4,null,null ,null,6,null ,null,null,7,
               6,1,8 ,3,4,7 ,2,5,9,

               null,null,9 ,null,null,5 ,null,7,null,
               null,4,5 ,null,null,8 ,3,9,2,
               null,6,1 ,7,2,9 ,4,null,null
            };
            var sgrid = creator.Create(3, list.ToArray());

            Assert.AreEqual(list[0], sgrid.Grid[0, 0].Cells[0, 0].Value, "0");
            Assert.AreEqual(list[1], sgrid.Grid[0, 0].Cells[0, 1].Value, "1");
            Assert.AreEqual(list[2], sgrid.Grid[0, 0].Cells[0, 2].Value, "2");
            Assert.AreEqual(list[3], sgrid.Grid[0, 1].Cells[0, 0].Value, "3");
            Assert.AreEqual(list[4], sgrid.Grid[0, 1].Cells[0, 1].Value, "4");
            Assert.AreEqual(list[5], sgrid.Grid[0, 1].Cells[0, 2].Value, "5");
            Assert.AreEqual(list[6], sgrid.Grid[0, 2].Cells[0, 0].Value, "6");
            Assert.AreEqual(list[7], sgrid.Grid[0, 2].Cells[0, 1].Value, "7");
            Assert.AreEqual(list[8], sgrid.Grid[0, 2].Cells[0, 2].Value, "8");

            Assert.AreEqual(list[9], sgrid.Grid[0, 0].Cells[1, 0].Value, "9");
            Assert.AreEqual(list[10], sgrid.Grid[0, 0].Cells[1, 1].Value, "10");
            Assert.AreEqual(list[11], sgrid.Grid[0, 0].Cells[1, 2].Value, "11");
            Assert.AreEqual(list[12], sgrid.Grid[0, 1].Cells[1, 0].Value, "12");
            Assert.AreEqual(list[13], sgrid.Grid[0, 1].Cells[1, 1].Value, "13");
            Assert.AreEqual(list[14], sgrid.Grid[0, 1].Cells[1, 2].Value, "14");
            Assert.AreEqual(list[15], sgrid.Grid[0, 2].Cells[1, 0].Value, "15");
            Assert.AreEqual(list[16], sgrid.Grid[0, 2].Cells[1, 1].Value, "16");
            Assert.AreEqual(list[17], sgrid.Grid[0, 2].Cells[1, 2].Value, "17");
        }
    }
}
