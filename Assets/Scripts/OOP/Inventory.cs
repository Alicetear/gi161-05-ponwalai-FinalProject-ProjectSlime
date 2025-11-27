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

    public bool UseKey()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] is Key)
            {
                Debug.Log("Use Key Open Door!");
                items.RemoveAt(i);
                return true;
            }
        }
        Debug.Log("No key.");
        return false;
    }

}
