using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus {

	public class MainMenu : GUIMenu {
		protected override void Initialize() {
			transform.Find("FreePlayButton").GetComponent<Button>().onClick.AddListener(() => {
				SceneController.LoadScene("Earth");
			});
			transform.Find("EventModeButton").GetComponent<Button>().onClick.AddListener(() => {
				GetController().GetEventMenu().SetActive(true);
			});
			transform.Find("SettingsButton").GetComponent<Button>().onClick.AddListener(() => {
				GetController().GetSettingsMenu().SetActive(true);
			});
			transform.Find("QuitButton").GetComponent<Button>().onClick.AddListener(() => {
				Debug.Log("[MainMenu] Quit Button pressed, exiting application...");
				UnityEditor.EditorApplication.isPlaying = false;
				Application.Quit();
			});
		}

		protected override void UpdateMenu() {
			
		}
	}
}