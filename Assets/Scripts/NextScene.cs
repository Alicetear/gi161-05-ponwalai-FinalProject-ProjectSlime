using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public float delay = 48.2f;     
    public string nextSceneName = "Game";
    public PlayableDirector director;

    [System.Obsolete]
    void Start()
    {
        if (director == null)
            director = FindObjectOfType<PlayableDirector>();

        director.stopped += OnTimelineFinished;
    }

    private void OnTimelineFinished(PlayableDirector director)
    {
        SceneManager.LoadScene(nextSceneName);
    }

}
