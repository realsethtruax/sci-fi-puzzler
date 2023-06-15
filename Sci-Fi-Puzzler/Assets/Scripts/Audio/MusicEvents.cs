using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 

public class MusicEvents : MonoBehaviour
{
    [field: SerializeField] public EventReference None {get; private set;}
    public SceneTracks[] musicLibrary;
  
    private void Awake()
    { 
        // Singleton implementation
        if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
        instance = this;
    }

    public static MusicEvents instance {get; private set;}

    public EventReference FindMusicForSceneName(string sceneName)
    {
        int returnIndex = -1;
        for (int i = 0; i < musicLibrary.Length; i++)
        {
            if (musicLibrary[i].sceneName == sceneName)
            {
                returnIndex = i;
                break;
            }
        }
        if (returnIndex != -1)
        {
            return musicLibrary[returnIndex].tracks;
        }
        else
        {
            Debug.LogError($"Entry with sceneName {sceneName} was not found in the musicLibrary.");
            return default;
        }
    }
}
[System.Serializable] public struct SceneTracks
{
    public string sceneName;
    public EventReference tracks;

}
