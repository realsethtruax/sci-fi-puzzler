using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    private static OptionsMenu instance;

    private void Awake()
    {
        // Check if an instance of the script already exists
        if (instance == null)
        {
            // If not, set the instance to this script and mark it to not be destroyed on scene load
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this script's game object
            Destroy(gameObject);
        }
    }
}
