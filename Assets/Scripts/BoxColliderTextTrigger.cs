using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class BoxColliderTextTrigger : MonoBehaviour
{
    public GameObject ReadablePopupScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (ReadablePopupScreen != null)
        {
            ReadablePopupScreen.SetActive(true);
        }
    }
}
