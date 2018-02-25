using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThreadBufferTest
{
    [TestClass]
    public class CircleBufferTest
    {
        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(new ThreadCircleBuffer.CircleBuffer<int>(5).IsEmpty == true);
        }

        [TestMethod]
        public void IsFullTest()
        {
            Assert.IsFalse(new ThreadCircleBuffer.CircleBuffer<int>(5).IsFull == true);
        }
    }
}
