using System.Threading;


namespace ThreadCircleBuffer
{
    public abstract class MyThread
    {
        readonly Thread _thread;

        protected static readonly object _locker = new object( );

        public MyThread( CircleBuffer<int> circleBuffer)
        {
            _thread = new Thread(Run);
            _thread.Start( );
        }

        public abstract void Run();
    }
}
