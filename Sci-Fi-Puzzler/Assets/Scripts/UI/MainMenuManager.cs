using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dropdownFieldText;

    public void PlayGame()
    {
        string sceneName = "SampleScene";
        SceneManager.LoadScene(sceneName);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("The quit button has been pressed");
        Application.Quit();
    }

    public void LoadSceneFromTextField()
    {
        string sceneName = dropdownFieldText.text.Trim();
        Debug.Log("Scene to load: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
