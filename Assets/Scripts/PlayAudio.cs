using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

     AudioSource source;
     private bool played;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!played) {
            played = true;
            source.Play();
        }
    }
}
