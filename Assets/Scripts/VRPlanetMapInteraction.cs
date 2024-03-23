using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEditor.SearchService;
using System.Collections.Generic;
using System.Collections;
using Controller;

public class VRPlanetMapInteractions : MonoBehaviour
{
    public FadeScreen fadeScreen;
    private int scenesVisited = 0;
    [SerializeField]
    private string sceneToLoad;

    public void LoadSceneBasedOnName()
    {
        if (!string.IsNullOrEmpty(sceneToLoad)){
            StartCoroutine(GoToSceneRoutine());
            if (MenuController.isEventMode() && scenesVisited >= MenuController.getMaxScenes() && !MenuController.checkExceededTimeLimit())
            {
                scenesVisited = 0;
                MenuController.resetStartTime();
                SceneManager.LoadScene("MainMenu"); // TODO in the future, this will redirect to the next player menu
            }
            else
            {
                // No need to increment scenesVisited here, the Awake() method will increment it when the next scene loads
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        else{
            Debug.LogWarning("Add a scene name to the 'sceneToLoad' field");
        }
    }
    IEnumerator GoToSceneRoutine()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
    }
}
