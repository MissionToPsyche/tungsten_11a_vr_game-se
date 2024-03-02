using UnityEngine.UI;

namespace UI.Menus {
	
	public class EventMenu : GUIMenu {
		protected override void Initialize() {
			transform.Find("EventStartButton").GetComponent<Button>().onClick.AddListener(() => {
				
			});
			transform.Find("EventModeBackButton").GetComponent<Button>().onClick.AddListener(() => {
				GetController().GetMainMenu().SetActive(true);
			});
		}
		protected override void UpdateMenu() {
			
		}
	}
}