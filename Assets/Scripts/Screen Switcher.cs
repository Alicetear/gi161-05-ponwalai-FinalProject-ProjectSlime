using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitcher: MonoBehaviour
{
    public void OpenScene (int index)
    {
        SceneManager.LoadScene (index);
    }

    public void QuitGame()
    {
        Application.Quit ();
    }
}
