using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class SceneEndTrigger : MonoBehaviour
{
    public GameObject pleaseChooseWhichLocationToVisitNextObject;

     //AudioSource source;
     public AudioClip narratedAnouncement;
     public bool triggered;                               
     private bool gameIsPaused;

    void Start()
    {
       // source = GetComponent<AudioSource>();
        triggered = false;
        gameIsPaused = false;
    }
    
    void Update()
    {
        //gameIsPaused = GameObject.Find("Canvas").GetComponent<PauseMenu>().isPaused;
       // if (gameIsPaused) {
        //    source.Pause();
       // }
       // if (!gameIsPaused) {
        //    source.UnPause();
       // }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (pleaseChooseWhichLocationToVisitNextObject != null)
        {
            pleaseChooseWhichLocationToVisitNextObject.SetActive(true);
        }

        if (!triggered) {
            triggered = true;
            //source.PlayOneShot(narratedAnouncement, 1.0F);
        }
    }
}
