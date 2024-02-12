using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;


public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject eventModePopup;
    public Button freePlayButton;
    public Button eventGameButton;
    public Button settingsButton;
    public Button quitButton;

    public Button eventGoButton;
    public Button eventModeBackButton;
    public GameObject eventModeInput;

    protected static Boolean eventMode = false;    // Keep track of if we are in event mode
    protected static int maxScenes = 15;           // Max number of scenes a player can visit (to be used in event mode only)

    private void Start()
    {
        freePlayButton.onClick.AddListener(FreePlayStart);
        eventGameButton.onClick.AddListener(EventModePopup);
        settingsButton.onClick.AddListener(SettingsScene);
        quitButton.onClick.AddListener(QuitGame);
        eventGoButton.onClick.AddListener(EventModeGo);
        eventModeBackButton.onClick.AddListener(EventModeBack);
    }

    public void FreePlayStart()
    {
        SceneManager.LoadScene("Earth");
    }

    public void EventModePopup() 
    {
        mainMenu.SetActive(false);
        eventModePopup.SetActive(true);
    }

    public void EventModeGo()
    {
        string inputText = eventModeInput.GetComponent<TMP_InputField>().text;
        int inputNum = 0;
        Int32.TryParse(inputText, out inputNum);
        if (inputNum <= 0 || inputNum > 9)
        {
            EditorUtility.DisplayDialog("Warning",
                "Please enter a number 1 through 9", "OK");
        } else
        {
            maxScenes = inputNum;
            eventMode = true;
            SceneManager.LoadScene("Earth");
            Debug.Log("Max Scenes: " + maxScenes);
        }
    }

    public void EventModeBack()
    {
        eventModePopup.SetActive(false);
        mainMenu.SetActive(true);
    }

    public static int getMaxScenes()
    {
        return maxScenes;
    }

    public static Boolean isEventMode()
    {
        return eventMode;
    }

    public void SettingsScene()
    {
        Debug.Log("Settings page");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
