using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public static bool _isPaused = false;
    public static int _currentSceneIndex;

    [SerializeField]
    private GameObject pauseMenuPrefab;
    private GameObject pauseMenuInstance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandlePause();
        }
    }

    private void HandlePause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0;

            // Instantiate the prefab if it hasn't been instantiated yet
            if (pauseMenuInstance == null && pauseMenuPrefab != null)
            {
                pauseMenuInstance = Instantiate(pauseMenuPrefab);
            }
        }
        else
        {
            Time.timeScale = 1;

            // Remove the instantiated prefab if it exists
            if (pauseMenuInstance != null)
            {
                Destroy(pauseMenuInstance);
            }
        }
    }

    public void RemovePauseMenu()
    {
        if (pauseMenuInstance != null)
        {
            AudioManager.audioManagerInstance.PassCurrentAudioSettingsToSaveManager();
            Destroy(pauseMenuInstance);
            pauseMenuInstance = null;

            _isPaused = !_isPaused;

            Time.timeScale = 1;
        }
    }
}
