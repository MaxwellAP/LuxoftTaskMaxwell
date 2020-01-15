using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LuxoftTask.test
{
    [TestClass]
    public class MaxSumTest
    {
        [TestMethod]
        public void TestMethodSample1()
        {
            var input = new[] { 1, 2, 3, 1 };
            var output = FindSum(input);
            Assert.AreEqual(4, output);
        }

        [TestMethod]
        public void TestMethodSample2()
        {
            var input = new[] { 2, 7, 9, 3, 1 };
            var output = FindSum(input);
            Assert.AreEqual(12, output);
        }

        public int FindSum(int[] arr)
        {
            var length = arr.Length;
            int sum = 0;

            bool containsNegative = arr.Any(i => i < 0);

            if (containsNegative)
            {
                Assert.Fail("array contains negative integers");
            }

            for (int i = 0; i < length; i++)
            {                
                if (i == 0 || i % 2 == 0)
                {
                    var num = arr[i];

                    if (num >= 1 && num <= 1000000000)
                    {
                        sum += arr[i];
                    }
                }
            }
            return sum;
        }
    }
}
