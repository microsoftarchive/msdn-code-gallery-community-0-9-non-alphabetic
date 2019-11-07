using MSDN.FSharp;

using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSDN.FSharpExTest
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        public void TestHeapBasic()
        {
            var heap = new PriorityQueue<int, string>();

            heap.Enqueue(2, "2Marie");
            heap.Enqueue(5, "5Dylan");
            heap.Enqueue(6, "6Evie");
            heap.Enqueue(1, "1Carl");
            heap.Enqueue(9, "9Anna");
            heap.Enqueue(3, "3Darwin");
            heap.Enqueue(7, "7Indiana");

            KeyValuePair<int, string> item;

            item = heap.Dequeue();
            Assert.AreEqual<int>(1, item.Key, "Should be 1 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(2, item.Key, "Should be 2 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(3, item.Key, "Should be 3 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(5, item.Key, "Should be 5 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(6, item.Key, "Should be 6 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(7, item.Key, "Should be 7 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(9, item.Key, "Should be 9 but value is " + item.Value);
            
            Assert.AreEqual<int>(0, heap.Count, "List should be empty");
        }

        [TestMethod]
        public void TestHeapBasicEnum()
        {
            KeyValuePair<int, string> item;
            var heap = GetHeap();

            item = heap.Dequeue();
            Assert.AreEqual<int>(1, item.Key, "Should be 1 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(2, item.Key, "Should be 2 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(3, item.Key, "Should be 3 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(5, item.Key, "Should be 5 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(6, item.Key, "Should be 6 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(7, item.Key, "Should be 7 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(8, item.Key, "Should be 8 but value is " + item.Value);

            Assert.AreEqual<int>(1, heap.Count, "List should be empty");
        }

        [TestMethod]
        public void TestHeapBasicChangeKey()
        {
            KeyValuePair<int, string> item;
            var heap = GetHeap();

            Assert.IsTrue(heap.ContainsKey(2));

            heap.ChangeKey(1, 11);
            item = heap.Dequeue();
            Assert.AreEqual<int>(2, item.Key, "Should be 2 but value is " + item.Value);

            var values = heap.GetValues(11);
            Assert.AreEqual<int>(values.Length, 1, "Key 2 should only have 1 value.");
        }

        [TestMethod]
        public void TestHeapBasicRemoveKey()
        {
            KeyValuePair<int, string> item;
            var heap = GetHeap();

            Assert.IsTrue(heap.ContainsKey(2));
            heap.RemoveKey(2);
            Assert.AreEqual<int>(heap.Count, 7, "Heap should contains 7 items");

            item = heap.Dequeue();
            Assert.AreEqual<int>(1, item.Key, "Should be 1 but value is " + item.Value);
            item = heap.Dequeue();
            Assert.AreEqual<int>(3, item.Key, "Should be 3 but value is " + item.Value);
        }

        [TestMethod]
        public void TestHeapBasicVolume()
        {
            int length = 100000;
            PriorityQueue<string, int> heap = new PriorityQueue<string, int>(length);

            Random rand = new Random(length);
            int amount;

            for (int i = 0; i < length; i++)
            {
                amount = rand.Next(-length, length);
                heap.Enqueue(Guid.NewGuid().ToString("D"), amount);
            }

            DequeueCheck(heap);
        }

        [TestMethod]
        public void TestHeapBasicLoading()
        {
            int length = 500000;
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>(length);

            Random rand = new Random(length);
            int amount;

            for (int i = 0; i < length; i++)
            {
                amount = rand.Next(-length, length);
                list.Add(new KeyValuePair<string, int>(Guid.NewGuid().ToString("D"), amount));
            }

            Stopwatch swAdd = Stopwatch.StartNew();
            PriorityQueue<string, int> heapAdd = new PriorityQueue<string, int>();
            foreach (var item in list)
            {
                heapAdd.Enqueue(item.Key, item.Value);
            }
            swAdd.Stop();
            Console.WriteLine("loading Heap with O(n^2) based operation: {0}", swAdd.ElapsedMilliseconds);
            DequeueCheck(heapAdd);

            Stopwatch swInit = Stopwatch.StartNew();
            PriorityQueue<string, int> heapInit = new PriorityQueue<string, int>(list);
            swInit.Stop();
            Console.WriteLine("loading Heap with O(n) based operation: {0}", swInit.ElapsedMilliseconds);
            DequeueCheck(heapInit);
        }

        [TestMethod]
        public void TestHeapMergeLoading()
        {
            int length = 1000;
            PriorityQueue<string, int> heap = new PriorityQueue<string, int>(length);

            Random rand = new Random(length);
            int amount;

            for (int i = 0; i < length; i++)
            {
                amount = rand.Next(-length, length);
                heap.Enqueue(Guid.NewGuid().ToString("D"), amount);
            }

            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>(length);
            for (int i = 0; i < length; i++)
            {
                amount = rand.Next(-length, length);
                list.Add(new KeyValuePair<string, int>(Guid.NewGuid().ToString("D"), amount));
            }
            heap.Merge(list);

            DequeueCheck(heap);
        }

        private void DequeueCheck(PriorityQueue<string, int> heap)
        {
            KeyValuePair<string, int> prev = heap.Peek();
            KeyValuePair<string, int> item;

            for (int i = 0; i < heap.Count; i++)
            {
                item = heap.Dequeue();
                Assert.IsTrue(String.Compare(prev.Key, item.Key) <= 0, String.Format("Prev Value: {0}, not less than Curr Value: {1}", prev.Key, item.Key));
            }
        }

        private PriorityQueue<int, string> GetHeap()
        {
            var items = new Dictionary<int, string>();

            items.Add(2, "2Marie");
            items.Add(5, "5Dylan");
            items.Add(6, "6Evie");
            items.Add(9, "9Earl");
            items.Add(1, "1Carl");
            items.Add(8, "8Anna");
            items.Add(3, "3Darwin");
            items.Add(7, "7Indiana");

            return new PriorityQueue<int, string>(items);
        }
    }
}
