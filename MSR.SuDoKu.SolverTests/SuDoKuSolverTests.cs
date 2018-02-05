using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSR.SuDoKu.Grid;
using MSR.SuDoKu.Interfaces;
using MSR.SuDoKu.Interfaces.Grid;
using System.Collections.Generic;
using System.Linq;

namespace MSR.SuDoKu.Solver.Tests
{
    [TestClass()]
    public class SuDoKuSolverTests
    {
        private SuDoKuSolver solver = null;

        [TestInitialize()]
        public void Init_Solver()
        {
            solver = new SuDoKuSolver();
        }

        [TestMethod()]
        public void SolveTest_2x2()
        {
            ISuDoKuGrid sgrid = null;

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

            Assert.IsTrue(solver.Solve(2, out sgrid, list));
        }

        [TestMethod()]
        public void SolveTest_3x3_1()
        {
            ISuDoKuGrid sgrid = null;
            /*
             * *2* *53 748
             * *5* 1*6 *2*
             * 937 284 016
             * 
             * 5*3 8*2 164
             * 4** *6* **7
             * 618 347 259
             * 
             * **9 **5 *7*
             * *45 **8 392
             * *61 729 4**
             */
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

            Assert.IsTrue(solver.Solve(3, out sgrid, list));
        }

        [TestMethod()]
        public void SolveTest_3x3_2()
        {
            ISuDoKuGrid sgrid = null;
            /*
             
             *  *   *       *   *   *       *   *   2
             *  *   *       *   *   *       9   4   *
             *  *   3       *   *   *       *   *   5
               
             *  9   2       3   *   5       *   7   4
             8  4   *       *   *   *       *   *   *
             *  6   7       *   9   8       *   *   *
                                        
             *  *   *       7   *   6       *   *   *
             *  *   *       9   *   *       *   2   *
             4  *   8       5   *   *       3   6   *

             */
            var list = new List<int?>() {

                null,null,null, null,null,null, null,null,2,
                null,null,null, null,null,null, 9,4,null,
                null,null,3, null,null,null, null,null,5,

                null,9,2, 3,null,5, null,7,4,
                8,4,null, null,null,null, null,null,null,
                null,6,7, null,9,8, null,null,null,

                null,null,null, 7,null,6, null,null,null,
                null,null,null, 9,null,null, null,2,null,
                4,null,8, 5,null,null, 3,6,null

            };

            Assert.IsTrue(solver.Solve(3, out sgrid, list));
        }
    }
}