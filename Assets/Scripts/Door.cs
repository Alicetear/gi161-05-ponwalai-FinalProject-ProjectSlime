using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpened = false;

    [Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Slime player = collision.GetComponentInParent<Slime>();
        if (player == null) return;

        if (player.Inventory.UseKey())
        {
            UIInventory ui = FindObjectOfType<UIInventory>();
            if (ui != null)
            {
                ui.RemoveKeyFromUI();
            }

            OpenDoor();
        }
        else
        {
            Debug.Log("I Need a Key open Door");
        }
    }

    private void OpenDoor()
    {
        if (isOpened) return; 

        Debug.Log("Door Open!");
        isOpened = true;

        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }

        
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.enabled = false;
        }
    }
}
