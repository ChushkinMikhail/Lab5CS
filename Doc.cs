﻿using System;
using System.Collections;

public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
    private List<KeyValuePair<TKey, TValue>> items = new List<KeyValuePair<TKey, TValue>>();

    public void Add(TKey key, TValue value)
        {
        items.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

    public TValue this[TKey key]
        {
        get
            {
            var item = items.Find(i => EqualityComparer<TKey>.Default.Equals(i.Key, key));
            if (item.Equals(default(KeyValuePair<TKey, TValue>)))
                {
                throw new KeyNotFoundException($"The key '{key}' was not found in the dictionary.");
                }
            return item.Value;
            }
        }

    public int Count
        {
        get { return items.Count; }
        }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
        return items.GetEnumerator();
        }

    IEnumerator IEnumerable.GetEnumerator()
        {
        return GetEnumerator();
        }
    }

class MyProgram
    {
    static void Main()
        {
        MyDictionary<string, int> myDict = new MyDictionary<string, int>
            {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
            };

        Console.WriteLine("Count: " + myDict.Count);
        Console.WriteLine("\nValue for key 'two': " + myDict["two"]);

        Console.WriteLine("\nIterating through the dictionary:");
        foreach (var kvp in myDict)
            {
            Console.WriteLine($"   {kvp.Key}: {kvp.Value}");
            }
        }
    }
