using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        Character.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        Character.OnPlayerDeath -= EnableGameOverMenu;
    }


    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
