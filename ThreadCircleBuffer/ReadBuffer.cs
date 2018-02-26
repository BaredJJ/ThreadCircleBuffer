using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadCircleBuffer
{
    class ReadBuffer:MyThread
    {
        private bool _complete;

        public override void Run()
        {
            lock(_locker)
            {
                if (Program.circleBuffer.IsEmpty)
                    _complete = true;
                else
                    Program.circleBuffer.Dequeue( );               
            }
        }
    }
}
