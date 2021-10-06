using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableuc1
{
    class MyMapNode<K,V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)//constructor
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];

        }
        /// <summary>
        /// method to add 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        public void Add(K Key, V value)
        {
            int position = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = Key, Value = value };
            linkedlist.AddLast(item);
        }
        /// <summary>
        /// method to find array position
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public struct KeyValue<k, v>
        {

            public k Key { get; set; }
            public v Value { get; set; }
        }

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
    }
}

