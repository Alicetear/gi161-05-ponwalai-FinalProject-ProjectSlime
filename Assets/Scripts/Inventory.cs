using System;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory 
{
    private List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);
        Debug.Log($"Added item: {item.Name}, Total = {items.Count}");
    }

    public int CountItem<T>() where T : Item
    {
        int c = 0;
        foreach (var i in items)
            if (i is T) c++;
        return c;
    }

    public bool HasKey() => CountItem<Key>() > 0;

    public bool UseKey()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] is Key)
            {
                Debug.Log("Use Key Open Door");
                items.RemoveAt(i);
                return true;        
            }
        }

        Debug.Log("Not key");
        return false;              
    }


    internal void AddItem(Key key)
    {
        throw new NotImplementedException();
    }
}
