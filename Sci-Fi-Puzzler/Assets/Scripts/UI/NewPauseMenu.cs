using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPauseMenu : MonoBehaviour
{
    private PauseMenuManager pauseMenuManager;

    // Start is called before the first frame update
    void Awake()
    {
        pauseMenuManager = FindObjectOfType<PauseMenuManager>();
    }

    public void ResumeButtonHit()
    {
        //Time.timeScale = 1.0f;
        //Destroy(this.gameObject);
        pauseMenuManager.RemovePauseMenu();
    }

}
