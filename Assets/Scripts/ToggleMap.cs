using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleMap : MonoBehaviour
{
    public GameObject solarSystemMapObject;
    public GameObject VrSolarSystemMapObject;

    public GameObject VrSetup;

    private bool mapVisible = false;

    public GameObject sceneEndCanvas;
    public GameObject VrSceneEndCanvas;

    AudioSource source;

    public AudioClip systemErrorSound;

    void Start()
    {
        //sceneEndCanvas = GameObject.Find("SceneEndCanvas");
        //Debug.Log(sceneEndCanvas);
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleMap();
        }
        if (sceneEndCanvas != null && sceneEndCanvas.activeSelf) {
            solarSystemMapObject.SetActive(true);
        } 
        if (VrSceneEndCanvas != null && VrSceneEndCanvas.activeSelf) {
            VrSolarSystemMapObject.SetActive(true);
        }
    }

    public void PrimaryButtonPressed(InputAction.CallbackContext context) {
        if (context.performed) {
            toggleMap();
        }
    }

    private void toggleMap()
    {
        if ((sceneEndCanvas != null && sceneEndCanvas.activeSelf) || (VrSceneEndCanvas != null && VrSceneEndCanvas.activeSelf)) {
            source.PlayOneShot(systemErrorSound, 0.7F);
            return;
        }
        if (VrSetup != null && VrSetup.activeSelf) {
            VrSolarSystemMapObject.SetActive(mapVisible);
        }
        else {
            solarSystemMapObject.SetActive(mapVisible);
        }
        mapVisible = !mapVisible;
    }
}

