using System;
using System.Collections.Generic;

namespace Unity.Services.Core.Scheduler.Internal
{
    abstract class MinimumBinaryHeap
    {
        internal const float IncreaseFactor = 1.5f;
        internal const float DecreaseFactor = 2.0f;
    }

    class MinimumBinaryHeap<T> : MinimumBinaryHeap
    {
        /// <remarks>
        /// Members requiring thread safety:
        /// * <see cref="m_HeapArray"/>.
        /// * <see cref="Count"/>.
        /// </remarks>
        readonly object m_Lock = new object();

        readonly IComparer<T> m_Comparer;
        readonly int m_MinimumCapacity;

        T[] m_HeapArray;

        internal IReadOnlyList<T> HeapArray => m_HeapArray;

        public int Count { get; private set; }

        public T Min => m_HeapArray[0];

        public MinimumBinaryHeap(int minimumCapacity = 10)
            : this(Comparer<T>.Default, minimumCapacity) {}

        public MinimumBinaryHeap(IComparer<T> comparer, int minimumCapacity = 10)
            : this(null, comparer, minimumCapacity) {}

        internal MinimumBinaryHeap(ICollection<T> collection, IComparer<T> comparer, int minimumCapacity = 10)
        {
            if (minimumCapacity <= 0)
            {
                throw new ArgumentException("capacity must be more than 0");
            }

            m_MinimumCapacity = minimumCapacity;
            m_Comparer = comparer;

            lock (m_Lock)
            {
                Count = collection?.Count ?? 0;
                var startSize = Math.Max(Count, minimumCapacity);
                m_HeapArray = new T[startSize];

                if (collection is null)
                    return;

                // Reset count since we insert all items.
                Count = 0;
                foreach (var item in collection)
                {
                    Insert(item);
                }
            }
        }

        public void Insert(T item)
        {
            lock (m_Lock)
            {
                IncreaseHeapCapacityWhenFull();
                var itemIndex = Count;
                m_HeapArray[Count] = item;
                Count++;
                while (itemIndex != 0
                       && m_Comparer.Compare(m_HeapArray[itemIndex], m_HeapArray[GetParentIndex(itemIndex)]) < 0)
                {
                    Swap(ref m_HeapArray[itemIndex], ref m_HeapArray[GetParentIndex(itemIndex)]);
                    itemIndex = GetParentIndex(itemIndex);
                }
            }
        }

        void IncreaseHeapCapacityWhenFull()
        {
            if (Count != m_HeapArray.Length)
            {
                return;
            }

            var newCapacity = (int)Math.Ceiling(Count * IncreaseFactor);
            var newHeapArray = new T[newCapacity];
            Array.Copy(m_HeapArray, newHeapArray, Count);
            m_HeapArray = newHeapArray;
        }

        public void Remove(T item)
        {
            lock (m_Lock)
            {
                var itemIndex = IndexOf(item);
                if (itemIndex < 0)
                    return;

                while (itemIndex != 0)
                {
                    Swap(ref m_HeapArray[itemIndex], ref m_HeapArray[GetParentIndex(itemIndex)]);
                    itemIndex = GetParentIndex(itemIndex);
                }

                ExtractMin();
            }
        }

        int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (m_HeapArray[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public T ExtractMin()
        {
            lock (m_Lock)
            {
                if (Count <= 0)
                {
                    throw new InvalidOperationException("Can not ExtractMin: BinaryHeap is empty.");
                }

                var item = m_HeapArray[0];
                if (Count == 1)
                {
                    Count--;
                    m_HeapArray[0] = default;
                    return item;
                }

                Count--;
                m_HeapArray[0] = m_HeapArray[Count];
                m_HeapArray[Count] = default;
                MinHeapify();
                DecreaseHeapCapacityWhenSpare();
                return item;
            }
        }

        void DecreaseHeapCapacityWhenSpare()
        {
            var spareThreshold = (int)Math.Ceiling(m_HeapArray.Length / DecreaseFactor);
            if (Count <= m_MinimumCapacity
                || Count > spareThreshold)
            {
                return;
            }

            var newHeapArray = new T[Count];
            Array.Copy(m_HeapArray, newHeapArray, Count);
            m_HeapArray = newHeapArray;
        }

        void MinHeapify()
        {
            int currentIndex;
            var smallest = 0;
            do
            {
                currentIndex = smallest;
                UpdateSmallestIndex();
                if (smallest == currentIndex)
                {
                    return;
                }

                Swap(ref m_HeapArray[currentIndex], ref m_HeapArray[smallest]);
            }
            while (smallest != currentIndex);

            void UpdateSmallestIndex()
            {
                smallest = currentIndex;
                var leftChildIndex = GetLeftChildIndex(currentIndex);
                var rightChildIndex = GetRightChildIndex(currentIndex);

                UpdateSmallestIfCandidateIsSmaller(leftChildIndex);
                UpdateSmallestIfCandidateIsSmaller(rightChildIndex);
            }

            void UpdateSmallestIfCandidateIsSmaller(int candidate)
            {
                if (candidate >= Count
                    || m_Comparer.Compare(m_HeapArray[candidate], m_HeapArray[smallest]) >= 0)
                {
                    return;
                }

                smallest = candidate;
            }
        }

        static void Swap(ref T lhs, ref T rhs) => (lhs, rhs) = (rhs, lhs);

        static int GetParentIndex(int index) => (index - 1) / 2;

        static int GetLeftChildIndex(int index) => 2 * index + 1;

        static int GetRightChildIndex(int index) => 2 * index + 2;
    }
}
