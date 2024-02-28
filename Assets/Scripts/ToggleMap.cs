using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleMap : MonoBehaviour
{
    public GameObject ssMapObject;

    private bool mapVisible = false;

    GameObject sceneEndCanvas;

    AudioSource source;

    public AudioClip systemErrorSound;

    void Start()
    {
        sceneEndCanvas = GameObject.Find("SceneEndCanvas");
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleMap();
        }
    }

    public void PrimaryButtonPressed(InputAction.CallbackContext context) {
        if (context.performed) {
            toggleMap();
        }
    }

    private void toggleMap()
    {
        if (sceneEndCanvas.GetComponent<SceneEndTrigger>().triggered) {
            source.PlayOneShot(systemErrorSound, 0.7F);
        }
        mapVisible = !mapVisible;
        ssMapObject.SetActive(mapVisible);
    }

}

