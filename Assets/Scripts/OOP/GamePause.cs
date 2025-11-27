using System;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject menuCanvas;

    private void Start()
    {
        menuCanvas.SetActive(false);
    }


    public void ResumeGame()
    {
        menuCanvas.SetActive(false);
        PauseController.SetPause(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool newState = !menuCanvas.activeSelf;

            menuCanvas.SetActive(newState);
            PauseController.SetPause(newState);
        }
    }
}
