using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public float delay = 48.2f;     
    public string nextSceneName = "Game";

    void Start()
    {
        Invoke(nameof(GoNext), delay);
    }

    void GoNext()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
