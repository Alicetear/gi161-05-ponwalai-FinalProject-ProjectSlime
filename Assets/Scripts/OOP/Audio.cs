using UnityEngine;

public class Audio : MonoBehaviour
{
    public GameObject audioObj;
    private bool isPlaying = false;

    public void DropAudio()
    {
        if (isPlaying) return;
        isPlaying = true;

        Instantiate(audioObj, transform.position, transform.rotation);
        Invoke(nameof(ResetPlay), 0.1f);
    }

    void ResetPlay()
    {
        isPlaying = false;
    }
}
