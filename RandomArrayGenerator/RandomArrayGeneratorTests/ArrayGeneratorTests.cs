using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomGenerator;
using System.Collections.Generic;
using System.Linq;

namespace RandomArrayGeneratorTest
{
    [TestClass]
    public class ArrayGeneratorTests
    {
        ArrayGenerator generator = new ArrayGenerator();

        // check whether all elements in list are unique and are between 1 .. 10000
        [TestMethod]
        public void GenerateArrayDistinctTest()
        {
            List<int> list = generator.GenerateArray(10000);

            Assert.IsTrue(list.Distinct().Count() == list.Count());
            Assert.AreEqual(list.Min(), 1);
            Assert.AreEqual(list.Max(), 10000);
        }

        // check whether the randomizer is well-distributed
        [TestMethod]
        public void GenerateArrayWellDistributedTest()
        {
            int arrayLength = 100;
            int iterationsNumber = 10000;

            // matrix which represents numbers and all possible positions in a list
            List<List<int>> test = new List<List<int>>();
            for (int i = 0; i < arrayLength; i++)
            {
                List<int> inner = new List<int>(arrayLength);
                inner.AddRange(Enumerable.Repeat(0, arrayLength));
                test.Add(inner);
            }

            for (int i = 0; i < iterationsNumber; i++)
            {
                List<int> list = generator.GenerateArray(arrayLength);
                for (int j = 0; j < arrayLength; j++)
                {
                    test[j][list[j] - 1]++;
                }
            }

            double probability = 1.0 / arrayLength;

            foreach (var i in test)
            {
                foreach (var j in i)
                {
                    Assert.AreEqual(probability, j / (double)iterationsNumber, 0.001);
                }
            }
        }
    }
}
