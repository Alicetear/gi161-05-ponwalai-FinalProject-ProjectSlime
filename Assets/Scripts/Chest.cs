using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public bool IsOpened { get; private set; }
    public string ChestID { get; private set; }
    public GameObject itemPrefab;
    public Sprite openedSprite;


    void Start()
    {
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObject);
    }


    public bool CanInteract()
    {
        return !IsOpened;
    }

    public void Interact()
    {
        if (!CanInteract()) return;  //openChest
    }

    private void OpenChest()
    {
        SetOpened(true);

        if (itemPrefab)
        {
            GameObject droppedItem = Instantiate(itemPrefab, transform.position + Vector3.down, Quaternion.identity);
            droppedItem.GetComponent<BounceEffect>().StartNounce();
        }

    }

    public void SetOpened(bool opened)
    {
        if (IsOpened = opened)
        {
            GetComponent<SpriteRanderer>().sprite = openedSprite;
        }





    }


}  
