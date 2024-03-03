using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus {
	
	public class EventMenu : GUIMenu {
		
		protected override void Initialize() {
			GameObject.Find("EventModeStartButton").GetComponent<Button>().onClick.AddListener(() => {
				GetController().GetNextPlayerMenu().SetActive(true);
			});
			GameObject.Find("EventModeBackButton").GetComponent<Button>().onClick.AddListener(() => {
				GetController().GetMainMenu().SetActive(true);
			});
		}
		protected override void UpdateMenu() {
			
		}
	}
}