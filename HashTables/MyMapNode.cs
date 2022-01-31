//-----------Dependencies-----------------//
using System;
using System.Collections.Generic;
using System.Text;
//------------Namespaces-----------------//
namespace HashTables
{
    internal class MyMapNode<K, V>
    {
       
            public struct KeyValue<K, V>
            {
                public K Key { get; set; }
                public V Value { get; set; }
            }
            private readonly int size;
            //int[] arr;
            private readonly LinkedList<KeyValue<K, V>>[] items;
            // Creating a constructor to initialize the values
           public MyMapNode(int size)
            {
                this.size = size;
                //arr new int [size];
                this.items = new LinkedList<KeyValue<K, V>>[size];
            }
            protected int GetArrayPosition(K key)
            {
                int hash = key.GetHashCode();
                int position = hash%size;
                return Math.Abs(position);
            }
            public V Get(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                        return item.Value;
                }
                return default(V);
            }
           //-------------Add The Elements--------------//
            public void Add(K key, V value) 
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                KeyValue<K, V> item = new KeyValue<K, V>() { Key=key, Value=value };
                linkedList.AddLast(item);
            }
        //---------------To Check Whether  Same Elements Present In the LinkedList --------------//
            public bool Exists(K key) 
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        return true;
                    }
                }
                return false;
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
        //---------Display Method is Used To Display the LinkedList-----//
        public void Display() 
            {
                foreach (var linkedList in items)
                {
                    if (linkedList != null)
                        foreach (var element in linkedList)
                        {
                            string res = element.ToString();
                            if (res !=null)
                                Console.WriteLine(element.Key +" " + element.Value);
                        }
                }
            }
        }
    }


