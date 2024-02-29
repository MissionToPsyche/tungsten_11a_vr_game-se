using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleMap : MonoBehaviour
{
    public GameObject ssMapObject;

    private bool mapVisible = false;

    public GameObject sceneEndCanvas;

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
            ssMapObject.SetActive(true);
        }
    }

    public void PrimaryButtonPressed(InputAction.CallbackContext context) {
        if (context.performed) {
            toggleMap();
        }
    }

    private void toggleMap()
    {
        if (sceneEndCanvas != null && sceneEndCanvas.activeSelf) {
            source.PlayOneShot(systemErrorSound, 0.7F);
            return;
        }
        mapVisible = !mapVisible;
        ssMapObject.SetActive(mapVisible);
    }

}

