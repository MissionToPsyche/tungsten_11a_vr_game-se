using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;

    public GameObject pauseMenu;
    public string mainMenuScene;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void ControllerMenuButtonPressed(InputAction.CallbackContext context) {
        Debug.Log("Start Button Pressed");
        if (context.performed) {
            if (isPaused)
            {   
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void ControllerSecondaryButtonPressed(InputAction.CallbackContext context) {
        Debug.Log("Secondary Button Pressed");
    }

    public void ControllerTriggerButtonPressed(InputAction.CallbackContext context) {
        Debug.Log("Trigger Button Pressed");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void LoadSettings()
    {
        Debug.Log("Setting Button Clicked");
        // TO DO: When a settings page is created, finish this method.
    }
}
