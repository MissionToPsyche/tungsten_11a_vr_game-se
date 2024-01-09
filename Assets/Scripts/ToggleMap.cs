using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ToggleMap : MonoBehaviour
{
    public GameObject ssMapObject;

    private bool mapVisible = false;

    private List<InputDevice> devices;

    void Start()
    {
        devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        if (devices.Count == 0) {
            Debug.Log("No VR devices have been detected in ToggleMap.cs");
            return;
        }

        //if perfomance is an issue, try removing devices that don't have the characteristics we need
        foreach (var device in devices)
        {
            //CheckPrimaryButton(device);
            Debug.Log(string.Format("Device found with name '{0}' and characterisitcs '{1}'", device.name, device.characteristics.ToString()));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || PrimaryKeyPressed())
        {
            toggleMap();
        }
    }

    private void toggleMap()
    {
        mapVisible = !mapVisible;
        ssMapObject.SetActive(mapVisible);
    }

    private bool PrimaryKeyPressed() {
        foreach (var device in devices)
        {
            bool isKeyPressed;
            if (device.TryGetFeatureValue(CommonUsages.primaryButton, out isKeyPressed) && isKeyPressed)
            {
                Debug.Log("Toggle button is pressed.");
                return true;
            }
        }
        return false;
    }
}

