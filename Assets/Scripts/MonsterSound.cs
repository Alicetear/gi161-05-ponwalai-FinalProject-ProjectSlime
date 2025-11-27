using UnityEngine;

public class MonsterSound : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioSource audioSource;
    public AudioClip proximitySound;

    private bool hasPlayed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (hasPlayed) return;

        audioSource.PlayOneShot(proximitySound);
        hasPlayed = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        hasPlayed = false; 
    }
}
