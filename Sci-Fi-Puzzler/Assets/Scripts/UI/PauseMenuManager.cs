using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static bool _isPaused = false;
    public static int _currentSceneIndex;

    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandlePause();
        }
    }

    private async void HandlePause()
    {
        _isPaused = !_isPaused;
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (_isPaused)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            await Task.Yield();
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("PauseMenu");
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_currentSceneIndex));
        }
    }
}
