using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ToggleMap : MonoBehaviour
{
    public GameObject ssMapObject;

    private bool mapVisible = false;

    private List<InputDevice> devicesWithPrimaryButton;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        if (devices.Count == 0) {
            Debug.Log("No VR devices have been detected in ToggleMap.cs");
            return;
        }

        foreach (var device in devices)
        {
            //CheckPrimaryButton(device);
            Debug.Log(string.Format("Device found with name '{0}' and characterisitcs '{1}'", device.name, device.characteristics.ToString()));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleMap();
        }
    }

    private void toggleMap()
    {
        mapVisible = !mapVisible;
        ssMapObject.SetActive(mapVisible);
    }
}
