using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus {
	public class ControlsMenu : GUIMenu {

		protected override void Initialize() {
			GameObject.Find("ControlsBackButton").GetComponent<Button>().onClick.AddListener(() => {
				GetController().GetSettingsMenu().SetActive(true);
			});
		}
	
		protected override void UpdateMenu() {
		
		}
	}
}