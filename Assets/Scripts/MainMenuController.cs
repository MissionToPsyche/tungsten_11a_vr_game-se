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
    public GameObject creditsMenu;
    public Button creditsButton;
    public Button creditsBackButton;
    public GameObject disclaimerMenu;
    public Button disclaimerButton;
    public Button disclaimerBackButton;
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
        creditsButton.onClick.AddListener(CreditsMenu);
        creditsBackButton.onClick.AddListener(CreditsBackButton);
        disclaimerButton.onClick.AddListener(DisclaimerMenu);
        disclaimerBackButton.onClick.AddListener(DisclaimerBackButton);
        eventGoButton.onClick.AddListener(EventModeGo);
        eventModeBackButton.onClick.AddListener(EventModeBack);

        // On start, ensure the menus are set to the correct visibility
        mainMenu.SetActive(true);
        eventModePopup.SetActive(false);
        creditsMenu.SetActive(false);
        disclaimerMenu.SetActive(false);

    }

    private void Awake()
    {
        // If a player navigates back to the main menu while it is in event mode, we should disable free play to prevent users from getting around the event mode rules
        // The only way event mode can be turned off is if quit (in the future we should add an 'event mode off' button
        if (isEventMode())
        {
            freePlayButton.enabled = false;
        }
        else
        {
            freePlayButton.enabled = true;
        }
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

    public void CreditsMenu()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CreditsBackButton()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void DisclaimerMenu()
    {
        creditsMenu.SetActive(false);
        disclaimerMenu.SetActive(true);
    }

    public void DisclaimerBackButton()
    {
        disclaimerMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
}
