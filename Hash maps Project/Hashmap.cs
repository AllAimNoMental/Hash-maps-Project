using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;
namespace HashMapLesson
{
    public class HashTable
    {
        // One entry in a bucket. Next links to the next entry in the same bucket.
        private class Node
        {
            public string Key;
            public int Value;
            public Node Next;
            public Node(string key, int value)
            {
                Key = key;
                Value = value;
            }
        }
        private readonly Node[] dataMap;
        public HashTable(int size = 7)
        {
            dataMap = new Node[size];
        }
        // Turns a key into a bucket index between 0 and dataMap.Length - 1
        private int Hash(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                int asciiValue = c;
                hash = (hash + asciiValue * 23) % dataMap.Length;
            }
            return hash;
        }
        // Adds a new key, or updates the value if the key already exists
        public void Set(string key, int value)
        {
            int index = Hash(key);
            Node temp = dataMap[index];
            if (temp == null)
            {
                dataMap[index] = new Node(key, value);
                return;
            }
            while (true)
            {
                if (temp.Key.Equals(key))
                {
                    temp.Value = value;
                    return;
                }
                if (temp.Next == null)
                    break;
                temp = temp.Next;
            }
            temp.Next = new Node(key, value);
        }
        // Finds the node for a key, or returns null when the key is missing
        private Node FindNode(string key)
        {
            Node temp = dataMap[Hash(key)];
            while (temp != null)
            {
                if (temp.Key.Equals(key))
                    return temp;
                temp = temp.Next;
            }
            return null;
        }
        // Returns the value for a key, or 0 when the key is missing
        public int Get(string key)
        {
            Node found = FindNode(key);
            return found == null ? 0 : found.Value;
        }
        //Contains Key method 10 pts
        public bool ContainsKey(string key)
        {
            return FindNode(key) != null;
        }
        // Removes a key. Returns true when a node was removed.
        public bool Remove(string key)
        {
            int index = Hash(key);
            Node previous = null;
            Node temp = dataMap[index];
            while (temp != null)
            {
                if (temp.Key.Equals(key))
                {
                    if (previous == null)
                        dataMap[index] = temp.Next; // removing the first node the bucket
                    else
                        previous.Next = temp.Next; // skip over the removed node
                    return true;
                }
                previous = temp;
                temp = temp.Next;
            }
            return false;
        }
        // Collects every key by visiting every bucket and every node in each chain
        public List<string> Keys()
        {
            var allKeys = new List<string>();
            for (int i = 0; i < dataMap.Length; i++)
            {
                Node temp = dataMap[i];
                while (temp != null)
                {
                    allKeys.Add(temp.Key);
                    temp = temp.Next;
                }
            }
            return allKeys;
        }
        // Prints each bucket and the chain inside it
        public void PrintTable()
        {
            for (int i = 0; i < dataMap.Length; i++)
            {
                Console.Write(i + ": ");
                Node temp = dataMap[i];
                if (temp == null)
                    Console.Write("null");
                while (temp != null)
                {
                    Console.Write("[" + temp.Key + " = " + temp.Value + "] ");
                    temp = temp.Next;
                }
                Console.WriteLine();
            }
        }
        //Try get method 10 points
        public bool TryGet(string key, out int value)
        {
            Node node = FindNode(key);
            if (node != null)
            {
                value = node.Value;
                return true;
            }
            else
            {
                value = 0;
                return false;
            }
        }

        public static (string Word, int Count) MostFrequentWord(string text)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();

            string[] words = text.ToLower().Split(' ', ',', '.');
            // everythin to lowercase and we separate each word if thre is a space comma or dot , and we saved them in our array list

            foreach (string word in words)
            {
                if (counts.ContainsKey(word))
                {
                    // if the key already was found then we add 1 to the value for the counter
                    counts[word] = counts[word] + 1;
                }
                else
                {
                    //add to the dictionary with value 1 in case is the first time we find the value
                    counts[word] = 1;
                }
            }
            string word1 = "";
            int mostCommon = 0;
            foreach (var word in counts)
            {
                if (word.Value != null)
                {
                    mostCommon = word.Value;
                    word1 = word.Key;
                }
            }
            return (word1, mostCommon);
        }
        public static HashSet<string> CommonNames(string[] first, string[] second)
        {
            HashSet<string> common = new HashSet<string>(first);
            common.IntersectWith(second);
            return common;
            // we compared both arrays and at the ned the hashset is going to keep the names that appears in both becasue intersatioin with modify the original hashset.
        }

    }
}








