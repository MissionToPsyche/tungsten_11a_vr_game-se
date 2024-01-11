using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleMap : MonoBehaviour
{
    public GameObject ssMapObject;

    private bool mapVisible = false;

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
        mapVisible = !mapVisible;
        ssMapObject.SetActive(mapVisible);
    }

}

