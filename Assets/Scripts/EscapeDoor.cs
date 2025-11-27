using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    public GameObject escapePanel;  

    private void Start()
    {
        if (escapePanel != null)
            escapePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached escape waypoint!");

            if (escapePanel != null)
                escapePanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
