using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

     AudioSource source;
     private bool played;
     private bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        played = false;
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        //gameIsPaused = GameObject.Find("Canvas").GetComponent<PauseMenu>().isPaused;
        if (gameIsPaused) {
            source.Pause();
        }
        if (!gameIsPaused) {
            source.UnPause();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!played) {
            played = true;
            source.Play();
        }
    }
}
