using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("UI Inventory")]
    public List<Image> slots = new List<Image>();

    [Header("icon Key")]
    public Sprite keyIcon;

    public void AddKeyToUI()
    {
        foreach (Image slot in slots)
        {
            if (slot.sprite == null)
            {
                slot.sprite = keyIcon;
                slot.color = Color.white;
                return;
            }
        }

        Debug.Log("Inventory UI เต็มแล้ว!");
    }
}