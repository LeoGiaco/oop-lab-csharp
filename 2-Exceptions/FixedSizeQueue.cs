namespace Exceptions
{
    // TODO understand the functioning of this class
    public class FixedSizeQueue : IFixedSizeQueue
    {
        private object[] _items;
        private int _firstIndex = 0;
        private int _lastIndex = 0;
        
        public FixedSizeQueue(uint capacity)
        {
            Capacity = capacity;
            _items = new object[capacity];
        }
        
        public uint Capacity { get; }

        public uint Count => (uint) (_lastIndex - _firstIndex);

        public object GetFirst()
        {
            if (Count > 0)
                return _items[_firstIndex++ % Capacity];
            throw new EmptyQueueException("The queue is empty.");
        }
        
        public void AddLast(object item)
        {
            if(Count < Capacity)
                _items[_lastIndex++ % Capacity] = item;
            else
                throw new FullQueueException("Queue is full.");
        }
    }
}
