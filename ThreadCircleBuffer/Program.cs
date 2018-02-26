using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadCircleBuffer
{
    class Program
    {
        public static CircleBuffer<int> circleBuffer;

        private static int GetInt<T>(T t)
        {
            int n;
            if (!int.TryParse(t.ToString( ), out n))
                throw new FormatException("Incorrect data type");

            return n;
        }

        private static int GetValue(string message)
        {
            Console.Write(message);
            return GetInt(Console.ReadLine( ));
        }

        static void Main(string[] args)
        {
            int writer = GetValue("Please enter to count threads for writer: ");

            int reader = GetValue("Please enter to count threads for reader: ");

            int sizeBuffer = GetValue("Please enter to length of buffer: ");

            circleBuffer = new CircleBuffer<int>(sizeBuffer);

            MyThread[] writers = new WriteBuffer[writer];

            MyThread[] readers = new ReadBuffer[reader];

            Random random = new Random();
            WriteBuffer.Count = random.Next(sizeBuffer, sizeBuffer * 4);

            for (int i = 0; i < writer; i++)
            {
                writers[i] = new WriteBuffer(new object( ));
                if(i == writer - 1)
                    for(int j = 0; j < reader; j++)
                    {
                        readers[j] = new ReadBuffer(new object( ));
                    }
            }
          
        }
    }
}
