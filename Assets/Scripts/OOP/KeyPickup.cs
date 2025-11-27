using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private bool picked = false; 

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (picked) return; 
        picked = true;

        Slime player = collision.GetComponentInParent<Slime>();
        if (player == null) return;

        player.Inventory.Add(new Key());
        Debug.Log("Player picked a key!");

        UIInventory ui = FindObjectOfType<UIInventory>();
        if (ui != null)
            ui.AddKeyToUI();

        Destroy(gameObject);
    }
}
