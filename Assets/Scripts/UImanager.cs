using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject gameOverMenu;
    private LoadSceneMode buildIndex;

    private void OnEnable()
    {
        Slime.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        Slime.OnPlayerDeath -= EnableGameOverMenu;
    }


    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainManu");
    }

    public void quit() 
    {
        Application.Quit();
    }


}
