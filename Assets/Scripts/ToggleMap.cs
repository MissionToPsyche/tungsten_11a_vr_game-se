using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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

    private void toggleMap()
    {
        mapVisible = !mapVisible;
        ssMapObject.SetActive(mapVisible);
    }
}
