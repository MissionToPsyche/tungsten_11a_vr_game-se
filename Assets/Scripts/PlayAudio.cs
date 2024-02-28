using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    const float VOLUME_INCREASE_DURATION = 2f;          //Amount of time to gradually increase the volume so it doesn't sound like a volume jump
    const float TARGET_AMBIENT_VOLUME = 0.5f;          //Target volume for the ambient music after all of the scripts play
    public GameObject ambientMusic;                     //Game object for the ambient music
    public bool isLastCollider;                         //Boolean to indicate if the collider is the last one in the scene
     AudioSource source;                                //Script audio source
     private bool played;                               //Boolean to keep track of if the audio has been played 
     private bool gameIsPaused;                         //Boolean to keep track of if the game is paused
    public AudioClip clip;

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
            // If this is the last collider and the audio source has a valid clip
            if (isLastCollider && source.clip != null)
            {
                Invoke("PlayClip", 20f);
                if (ambientMusic)
                {
                    // Start a coroutine to increase the volume of the ambient music after the audio clip length
                    StartCoroutine(IncreaseVolumeAfterDelay(ambientMusic.GetComponent<AudioSource>(), source.clip.length));
                }
            }

        }
    }

    private void PlayClip() {
        source.PlayOneShot(clip, 1.0F);
    }

    // Coroutine to increase the volume of the ambient music after a delay
    private System.Collections.IEnumerator IncreaseVolumeAfterDelay(AudioSource ambientAudioSource, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Increase the volume of the ambient music
        ambientAudioSource.volume = 0.05f;
        float startVolume = ambientAudioSource.volume;
        float startTime = Time.time;

        while (Time.time < startTime + VOLUME_INCREASE_DURATION)
        {
            float elapsed = Time.time - startTime;
            float t = elapsed / VOLUME_INCREASE_DURATION;
            ambientAudioSource.volume = Mathf.Lerp(startVolume, TARGET_AMBIENT_VOLUME, t);
            yield return null;
        }

        // Ensure the volume is set to the target value after interpolation
        ambientAudioSource.volume = TARGET_AMBIENT_VOLUME;
    }
}
