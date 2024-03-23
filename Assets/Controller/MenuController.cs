using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;
using System.Collections;
using UI.Menus;

namespace Controller {
	public class MenuController : MonoBehaviour {
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
		public GameObject eventModeSceneLimitInput;
		public GameObject eventModeTimeLimitInput;
		public FadeScreen fadeScreen;

		static Boolean _eventMode; // Keep track of if we are in event mode
		static int _maxScenes = 15; // Max number of scenes a player can visit (to be used in event mode only)
		static double _timeLimit = 20; // Time limit per turn while in event mode
		static DateTime _startTime; // Time in which the game starts

		GUIMenu activeMenu;
		MainMenu mainMenu;
		EventMenu eventMenu;
		NextPlayerMenu nextPlayerMenu;
		SettingsMenu settingsMenu;
		ControlsMenu controlsMenu;

		void Start() {
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
			mainMenu = FindObjectOfType<MainMenu>();
			mainMenu.SetActive(true);
			eventMenu = FindObjectOfType<EventMenu>();
			nextPlayerMenu = FindObjectOfType<NextPlayerMenu>();
			settingsMenu = FindObjectOfType<SettingsMenu>();
			controlsMenu = FindObjectOfType<ControlsMenu>();
		}

		void Awake() {
			// If a player navigates back to the main menu while it is in event mode, we should disable free play to prevent users from getting around the event mode rules
			// The only way event mode can be turned off is if quit (in the future we should add an 'event mode off' button
			if (isEventMode()) {
				freePlayButton.enabled = false;
			}
			else {
				freePlayButton.enabled = true;
			}
		}

		IEnumerator GoToSceneRoutine() {
			fadeScreen.FadeOut();
			SceneManager.LoadScene("Earth");
			yield return new WaitForSeconds(fadeScreen.fadeDuration);
		}

		public void FreePlayStart() {
			_startTime = DateTime.Now;
			StartCoroutine(GoToSceneRoutine());
		}

		public void EventModePopup() {
			mainMenu.SetActive(false);
			eventModePopup.SetActive(true);
		}

		public void EventModeGo() {
			string sceneLimitInputText = eventModeSceneLimitInput.GetComponent<TMP_InputField>().text;
			string timeLimitInputText = eventModeTimeLimitInput.GetComponent<TMP_InputField>().text;
			bool parseSceneLimit = Int32.TryParse(sceneLimitInputText, out int sceneLimitInputNum);
			bool parseTimeLimit = Double.TryParse(timeLimitInputText, out double timeLimitInputNum);
			if (sceneLimitInputNum <= 0 || sceneLimitInputNum > 9 || !parseSceneLimit) {
				EditorUtility.DisplayDialog("Warning",
					"Please enter a number 1 through 9 for the scene limit.",
					"OK");
			}
			else if (timeLimitInputNum <= 0 || timeLimitInputNum > 60 || !parseTimeLimit) {
				EditorUtility.DisplayDialog("Warning",
					"Please enter a time limit in minutes between 1 and 60",
					"OK");
			}
			else {
				_maxScenes = sceneLimitInputNum;
				_eventMode = true;
				_timeLimit = timeLimitInputNum;
				_startTime = DateTime.Now;
				Debug.Log("Max Scenes: " + _maxScenes);
				Debug.Log("Time Limit: " + _timeLimit);
				StartCoroutine(GoToSceneRoutine());
			}
		}

		public void EventModeBack() {
			eventModePopup.SetActive(false);
			mainMenu.SetActive(true);
		}

		public static void resetStartTime() {
			_startTime = DateTime.Now;
		}

		public static bool checkExceededTimeLimit() {
			DateTime now = DateTime.Now;
			TimeSpan timePassed = now - _startTime;
			double minutesPassed = timePassed.TotalMinutes;
			if (minutesPassed > _timeLimit) {
				return true;
			}
			else {
				return false;
			}
		}

		public static int getMaxScenes() {
			return _maxScenes;
		}

		public static Boolean isEventMode() {
			return _eventMode;
		}

		public void SettingsScene() {
			Debug.Log("Settings page");
		}

		public void QuitGame() {
			EditorApplication.isPlaying = false;
			Application.Quit();
		}

		public void CreditsMenu() {
			mainMenu.SetActive(false);
			creditsMenu.SetActive(true);
		}

		public void CreditsBackButton() {
			creditsMenu.SetActive(false);
			mainMenu.SetActive(true);
		}

		public void DisclaimerMenu() {
			creditsMenu.SetActive(false);
			disclaimerMenu.SetActive(true);
		}

		public void DisclaimerBackButton() {
			disclaimerMenu.SetActive(false);
			creditsMenu.SetActive(true);
		}
		public void SetActiveMenu(GUIMenu guiMenu) {
			if(activeMenu != null) activeMenu.SetActive(false);
			activeMenu = guiMenu;
		}

		public MainMenu GetMainMenu() {
			return mainMenu;
		}

		public EventMenu GetEventMenu() {
			return eventMenu;
		}
		
		public NextPlayerMenu GetNextPlayerMenu() {
			return nextPlayerMenu;
		}
		
		public SettingsMenu GetSettingsMenu() {
			return settingsMenu;
		}

		public ControlsMenu GetControlsMenu() {
			return controlsMenu;
		}
	}
}