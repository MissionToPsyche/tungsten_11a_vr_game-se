using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus {
	
	public class NextPlayerMenu : GUIMenu {
		protected override void Initialize() {
			transform.Find("ReadyButton").GetComponent<Button>()?.onClick.AddListener(() => {
				GetController().GetEventMenu().SetActive(true);
			});
		}

		protected override void UpdateMenu() {
			
		}
	}
}