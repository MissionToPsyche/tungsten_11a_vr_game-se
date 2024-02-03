using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class VRPlanetMapInteractions : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    public void LoadSceneBasedOnName()
    {
        if (!string.IsNullOrEmpty(sceneToLoad)){
            SceneManager.LoadScene(sceneToLoad);
        }
        else{
            Debug.LogWarning("Add a scene name to the 'sceneToLoad' field");
        }
    }
}
