using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMenuInArea : MonoBehaviour
{
    public Transform parentObject;
    private float maxDistance = 4f;
    private Vector3 relativePosition = new Vector3(1, 0.8f, 2);
    private Rigidbody rigibBodyOfMenuItem; 

    void Start()
    {
        rigibBodyOfMenuItem = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, parentObject.position);

        if(currentDistance > maxDistance)
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
    }
}

