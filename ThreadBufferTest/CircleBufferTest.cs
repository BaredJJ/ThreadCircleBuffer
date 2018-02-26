using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreadCircleBuffer;

namespace ThreadBufferTest
{
    [TestClass]
    public class CircleBufferTest
    {
        Random random = new Random( );

        private bool CheckString(string first, string second)
        {
            if (first.Length != second.Length)
                return false;
            else if (first == null || second == null)
                    return false;

            for (int i = 0; i < first.Length; i++)
                if (first[i] != second[i])
                    return false;

            return true;
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(new CircleBuffer<int>(5).IsEmpty == true);
        }

        [TestMethod]
        public void IsFullTest()
        {
            Assert.IsFalse(new CircleBuffer<int>(5).IsFull == true);
        }

        [TestMethod]
        public void Length()
        {           
            CircleBuffer<int> buffer = new CircleBuffer<int>(random.Next(1,50));

            int length = random.Next(1, 30);

            for(int i = 0; i < length; i++)
            {
                buffer.Enqueue(random.Next(1, 300));
            }

            Assert.IsTrue(buffer.Length == length);
        }

        [TestMethod]
        public void WriteOver()
        {
            int length = random.Next(1, 50);

            CircleBuffer<int> buffer = new CircleBuffer<int>(length);

            int overLength = random.Next(50, 99);

            for (int i = 0; i < overLength; i++)
            {
                buffer.Enqueue(random.Next(1, 300));
            }

            Assert.IsTrue(buffer.Tail == overLength % length);
        }

        [TestMethod]
        public void AllDequeue()
        {
            CircleBuffer<int> buffer = new CircleBuffer<int>(random.Next(1, 50));

            int length = random.Next(1, 30);

            for (int i = 0; i < length; i++)
            {
                buffer.Enqueue(random.Next(1, 300));
            }

            for (int i = 0; i < length; i++)
                buffer.Dequeue( );

            Assert.IsTrue(buffer.IsEmpty);
        }

        [TestMethod]
        public void Queue()
        {
            int length = random.Next(10, 100);

            CircleBuffer<char> buffer = new CircleBuffer<char>(length);

            StringBuilder tempString = new StringBuilder( );

            for(int i = 0; i < length; i++)
            {
                char temp = (char)random.Next(0x0410, 0x44F);
                tempString.Append(temp);
                buffer.Enqueue(temp);
            }

            string prototype = tempString.ToString( );
            tempString = new StringBuilder( );

            for(int i = 0; i < length; i++)
            {
                tempString.Append(buffer.Dequeue( ));
            }

            Assert.IsTrue(CheckString(prototype, tempString.ToString( )));
        }

        [TestMethod]
        public void OverQueue()
        {
            int length = random.Next(10, 100);

            CircleBuffer<char> buffer = new CircleBuffer<char>(length);

            StringBuilder tempString = new StringBuilder( );

            int overLength = random.Next(1, 100);
            int cicleSize = length + overLength;
            int remainder = (cicleSize) % length;

            for (int i = 0; i < cicleSize; i++)
            {
                char temp = (char)random.Next(0x0410, 0x44F);
                if (i >= cicleSize - (remainder + (length - remainder)))
                    tempString.Append(temp);
                buffer.Enqueue(temp);
            }

            string prototype = tempString.ToString( );
            tempString = new StringBuilder( );

            for (int i = 0; i < length; i++)
            {
                tempString.Append(buffer.Dequeue( ));
            }

            Assert.IsTrue(CheckString(prototype, tempString.ToString( )));
        }
    }
}
