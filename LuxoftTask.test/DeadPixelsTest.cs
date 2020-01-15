using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuxoftTask.test
{
    [TestClass]
    public class DeadPixelsTest
    {

        public static int _rowCount { set; get; }
        public static int _colCount { set; get; }


        [TestMethod]
        public void TestMethodSample1()
        {
            var monitor = new[,] {
                {1, 0, 1},
                {0, 0, 0},
                {1, 0, 1} };

            var output = CountGroups(monitor);
            Assert.AreEqual(4, output);
        }


        [TestMethod]
        public void TestMethodSample2()
        {
            var monitor = new[,] {
                {1, 1, 1},
                {1, 0, 0},
                {1, 0, 1}};

            var output = CountGroups(monitor);
            Assert.AreEqual(2, output);
        }

        public int CountGroups(int[,] monitor)
        {
            if (monitor is null)
            {
                Assert.Fail("Object is null");
            }

            _rowCount = monitor.GetLength(0);
            _colCount = monitor.GetLength(1);            

            bool[,] groupPixel = new bool[_rowCount, _colCount];

            int count = 0;
            for (int i = 0; i < _rowCount; ++i)
            {
                for (int j = 0; j < _colCount; ++j)
                {
                    if (monitor[i, j] == 1 && !groupPixel[i, j])
                    {
                        DepthFirstSearch(monitor, i, j, groupPixel);
                        ++count;
                    }
                }
            }
            return count;
        }


        public void DepthFirstSearch(int[,] monitor, int row, int col, bool[,] groupPixel)
        {

            // rows and colluns neighbours 
            int[] rowNbr = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colNbr = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            groupPixel[row, col] = true;

            for (int k = 0; k < 8; ++k)
            {
                var rowCheck = row + rowNbr[k];
                var colCheck = col + colNbr[k];

                if (((rowCheck >= 0) && (rowCheck < _rowCount) && (colCheck >= 0) && (colCheck < _colCount)
                    && (monitor[rowCheck, colCheck] == 1 && !groupPixel[rowCheck, colCheck])))
                {
                    DepthFirstSearch(monitor, row + rowNbr[k],
                        col + colNbr[k], groupPixel);
                }
            }
        }


    }
}
