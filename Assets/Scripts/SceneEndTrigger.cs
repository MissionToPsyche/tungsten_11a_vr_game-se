using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class SceneEndTrigger : MonoBehaviour
{
    public GameObject pleaseChooseWhichLocationToVisitNextObject;

    private void OnTriggerEnter(Collider other)
    {
        if (pleaseChooseWhichLocationToVisitNextObject != null)
        {
            pleaseChooseWhichLocationToVisitNextObject.SetActive(true);
        }
    }
}
