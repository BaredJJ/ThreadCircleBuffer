using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadCircleBuffer
{
    class ReadBuffer:MyThread
    {
        public override void Run()
        {
            lock(_locker)
            {

            }
        }
    }
}
