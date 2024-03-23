namespace UI.Menus {
	public class SettingsMenu : GUIMenu {
		protected override void Initialize() {
			transform.Find("BackButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
				GetController().GetMainMenu().SetActive(true);
			});
			transform.Find("ControlsButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
				GetController().GetControlsMenu().SetActive(true);
			});
		}

		protected override void UpdateMenu() {
			
		}
	}
}