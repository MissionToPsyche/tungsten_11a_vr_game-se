using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus {

	public class MainMenu : GUIMenu {
		protected override void Initialize() {
			GameObject.Find("FreePlayButton").GetComponent<Button>().onClick.AddListener(() => {
				SceneController.LoadScene(SceneController.Scene.Earth);
			});
			GameObject.Find("EventModeButton").GetComponent<Button>().onClick.AddListener(() => {
				GetController().GetEventMenu().SetActive(true);
			});
			GameObject.Find("SettingsButton").GetComponent<Button>().onClick.AddListener(() => {
				GetController().GetSettingsMenu().SetActive(true);
			});
			GameObject.Find("QuitButton").GetComponent<Button>().onClick.AddListener(() => {
				Debug.Log("[MainMenu] Quit Button pressed, exiting application...");
				UnityEditor.EditorApplication.isPlaying = false;
				Application.Quit();
			});
		}

		protected override void UpdateMenu() {
			
		}
	}
}