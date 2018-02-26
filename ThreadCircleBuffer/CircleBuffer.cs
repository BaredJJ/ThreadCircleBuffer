using System;

namespace ThreadCircleBuffer
{
    public class CircleBuffer<T>
    {
        T[] _buffer;//Buffer

        int _head;//Pointer to head buffer

        int _tail;//Pointer to tail buffer

        int _length;//Length buffer

        static object _locked = new object( );//Sinhronization object

        public CircleBuffer(int bufferSize)
        {
            _buffer = new T[bufferSize];
            _head = bufferSize - 1;
        }

        public int Length => _length;//Need for test

        public int Tail => _tail;//Need for test

        /// <summary>
        /// Buffer is empty
        /// </summary>
        public bool IsEmpty => _length == 0;

        /// <summary>
        /// Buffer is full
        /// </summary>
        public bool IsFull => _length == _buffer.Length;

        /// <summary>
        /// Dequeue element from buffer
        /// </summary>
        /// <returns>element</returns>
        public T Dequeue()
        {
            lock(_locked)
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Queue is empty");

                T dequeued = _buffer[_tail];
                _tail = NextPosition( _tail );
                _length--;
                return dequeued;
            }
        }

        /// <summary>
        /// Add element in buffer
        /// </summary>
        /// <param name="value">element</param>
        public void Enqueue(T value)
        {
            lock (_locked)
            {
                _head = NextPosition(_head);
                _buffer[_head] = value;

                if (IsFull)
                    _tail = NextPosition(_tail);
                else _length++;
            }
        }

        /// <summary>
        /// Generate new pointer in buffer
        /// </summary>
        /// <param name="position">old pointer</param>
        /// <returns>new pointer</returns>
        private int NextPosition(int position)
        {
            return (position + 1) % _buffer.Length;
        }

    }
}
