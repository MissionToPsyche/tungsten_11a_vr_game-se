using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Manages and loads different scenes. Technically, I could just directly call SceneManager.LoadScene(), however I want
 * to log the scene changes and possibly add some additional functionality in the future.
 */
public class SceneController : MonoBehaviour {

	public enum Scene {
		MainMenu,
		Earth,
		Venus,
		Mercury,
		Mars,
		Jupiter,
		Saturn,
		Uranus,
		Neptune,
		Psyche
	}
	
	static Scene _currentScene = Scene.MainMenu;
	
    public static void LoadScene(Scene scene) {
	    Debug.Log("[SceneController] Scene Transition: " + _currentScene + " -> " + scene);
        SceneManager.LoadScene(scene.ToString());
        _currentScene = scene;
    }
    
    public static Scene GetCurrentScene() {
	    return _currentScene;
	}
}