using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpened = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Slime player = collision.GetComponentInParent<Slime>();
        if (player == null) return;

        if (player.Inventory.UseKey())
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("??????????????????????????!");
        }
    }

    private void OpenDoor()
    {
        if (isOpened) return; 

        Debug.Log("?????????????!");
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
