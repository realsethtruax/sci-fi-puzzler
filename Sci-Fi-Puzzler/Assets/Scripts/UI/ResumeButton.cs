using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{
    public void ResumeGame()
    {
        PauseMenuManager._isPaused = false;
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("PauseMenu");
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(PauseMenuManager._currentSceneIndex));
    }
}

