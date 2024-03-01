using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMenuInArea : MonoBehaviour
{
    public Transform parentObject;
    public Transform controlMenu;
    private float maxDistance = 3f;
    private Vector3 relativePosition = new Vector3(-0.5f, 0.5f, 0.6f);
    private Rigidbody rigibBodyOfMenuItem; 

    void Start()
    {
        rigibBodyOfMenuItem = GetComponent<Rigidbody>();
        controlMenu = transform.parent.Find("Control Menu Object");

        if (controlMenu == null)
        {
            Debug.LogError("Control Menu object not!");
        }
    }

    void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, parentObject.position);

        if(currentDistance > maxDistance)
        {
            ResetToRelativePosition();
        }
    }
    public void ResetPosition()
    {
        ResetToRelativePosition();
    }
    private void ResetToRelativePosition()
    {
        Vector3 newPosition = parentObject.TransformPoint(relativePosition);
        if (rigibBodyOfMenuItem != null)
        {
            rigibBodyOfMenuItem.MovePosition(newPosition);
        }
        else
        {
            transform.position = newPosition;
        }
    }

    public void toggleControlMenu()
    {
        if(controlMenu.gameObject.activeSelf)
        {
            controlMenu.gameObject.SetActive(false);
        }
        else
        {
            controlMenu.gameObject.SetActive(true);
        }
    }
}
