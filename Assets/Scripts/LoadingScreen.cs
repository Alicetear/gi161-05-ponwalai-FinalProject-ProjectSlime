using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Slider progressBar;

    void Start()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(0.3f);

        AsyncOperation op = SceneManager.LoadSceneAsync("Game");
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            progressBar.value = Mathf.Clamp01(op.progress / 0.9f);

            if (op.progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.5f);
                op.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
