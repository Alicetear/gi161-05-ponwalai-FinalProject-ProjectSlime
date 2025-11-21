using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitcher: MonoBehaviour
{
    public void OpenScene (int index)
    {
        SceneManager.LoadScene (index);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit ();
    }
}
