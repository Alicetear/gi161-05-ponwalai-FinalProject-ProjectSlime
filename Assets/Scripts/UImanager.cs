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

    void Start()
    {
        Time.timeScale = 1f;
        gameOverMenu.SetActive(false);
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
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
