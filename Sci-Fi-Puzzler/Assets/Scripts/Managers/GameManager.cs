using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instance Reference
    public static GameManager gameManagerInstance;

    public enum GameState { INITIALIZE, PLAYING, PAUSED, SAVING };
    [SerializeField] private GameState currentGamestate = GameState.INITIALIZE;

    private void Awake()
    {
        // Implement Singleton Pattern
        if (gameManagerInstance != null && gameManagerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        gameManagerInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentGamestate)
        {
            case GameState.INITIALIZE:
                // Load Persistent Data
                if (SaveManager.saveManagerInstance.GetInitialized()) {
                    AudioManager.audioManagerInstance.FetchAudioSettingsFromSaveManager();
                    AudioManager.audioManagerInstance.StartUp();
                    currentGamestate = GameState.PLAYING;
                }
                break;

            case GameState.PLAYING:

                break;

            case GameState.PAUSED:

                break;

            case GameState.SAVING:

                break;

            default:
                break;
        }
    }

    public void SetGameState(GameState game) {
        this.currentGamestate = game;
    }
}
