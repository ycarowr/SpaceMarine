using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableSortedDictionary<TKey, TValue> : SortedDictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] protected List<TKey> MyKeys = new List<TKey>();

    [SerializeField] protected List<TValue> MyValues = new List<TValue>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        MyKeys.Clear();
        MyValues.Clear();
        foreach (var pair in this)
        {
            MyKeys.Add(pair.Key);
            MyValues.Add(pair.Value);
        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        Clear();

        if (MyKeys.Count != MyValues.Count)
            throw new Exception(
                "there are keys and values after deserialization. Make sure that both key and value types are serializable.");

        for (var i = 0; i < MyKeys.Count; i++)
            Add(MyKeys[i], MyValues[i]);
    }
}

[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] protected List<TKey> MyKeys = new List<TKey>();

    [SerializeField] protected List<TValue> MyValues = new List<TValue>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        MyKeys.Clear();
        MyValues.Clear();
        foreach (var pair in this)
        {
            MyKeys.Add(pair.Key);
            MyValues.Add(pair.Value);
        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        Clear();

        if (MyKeys.Count != MyValues.Count)
            throw new Exception(
                "there are keys and values after deserialization. Make sure that both key and value types are serializable.");

        for (var i = 0; i < MyKeys.Count; i++)
            Add(MyKeys[i], MyValues[i]);
    }
}