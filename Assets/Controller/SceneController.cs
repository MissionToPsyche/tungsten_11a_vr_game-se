using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Manages and loads different scenes. Technically, I could just directly call SceneManager.LoadScene(), however I want
 * to log the scene changes and possibly add some additional functionality in the future.
 */
public class SceneController : MonoBehaviour {

	static string _currentScene = "MainMenu";
	
    public static void LoadScene(string sceneName) {
	    Debug.Log("[SceneController] Scene Transition: " + _currentScene + " -> " + sceneName);
        SceneManager.LoadScene(sceneName);
        _currentScene = sceneName;
    }
}