using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public Button freePlayButton;
    public Button eventGameButton;
    public Button settingsButton;
    public Button quitButton;
    
    private void Start()
    {
        freePlayButton.onClick.AddListener(FreePlayStart);
        eventGameButton.onClick.AddListener(EventGameStart);
        settingsButton.onClick.AddListener(SettingsScene);
        freePlayButton.onClick.AddListener(QuitGame);
    }

    public void FreePlayStart()
    {
        SceneManager.LoadScene("Earth");
    }

    public void EventGameStart() 
    {
        Debug.Log("Start event game! TBI");
    }

    public void SettingsScene()
    {
        Debug.Log("Settings page");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
