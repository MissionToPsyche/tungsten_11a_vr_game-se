using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.XR;
// using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ToggleMap : MonoBehaviour
{
    public GameObject ssMapObject;

    private bool mapVisible = false;

   // private List<UnityEngine.XR.InputDevice> devices;

    void Start()
    {
        // devices = new List<UnityEngine.XR.InputDevice>();
        // InputDevices.GetDevices(devices);

        // if (devices.Count == 0) {
        //     Debug.Log("No VR devices have been detected in ToggleMap.cs");
        //     return;
        // }

        // //if perfomance is an issue, try removing devices that don't have the characteristics we need
        // foreach (var device in devices)
        // {
        //     //CheckPrimaryButton(device);
        //     Debug.Log(string.Format("Device found with name '{0}' and characterisitcs '{1}'", device.name, device.characteristics.ToString()));
        // }
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
        mapVisible = !mapVisible;
        ssMapObject.SetActive(mapVisible);
    }

    // private bool PrimaryKeyPressed() {
    //     foreach (var device in devices)
    //     {
    //         bool isKeyPressed;
    //         if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out isKeyPressed) && isKeyPressed)
    //         {
    //             Debug.Log("Toggle button is pressed.");
    //             return true;
    //         }
    //     }
    //     return false;
    // }

}

