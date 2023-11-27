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
        ReadablePopupScreen.SetActive(true);
    }
}
