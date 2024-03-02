using Controller;
using UnityEngine;

namespace UI.Menus {
	/**
	 * Base class for all GUI menus.
	 */
	public abstract class GUIMenu : GUIElement {
		
		private Camera _camera;
		private bool _needsUpdate;
		
		private void Start() {
		    Initialize();
		    _camera = Camera.main;
		 }

		private void Update() {
			if(IsActive()) {
				if(_needsUpdate) {
					UpdateMenu();
					_needsUpdate = false;
				}
				transform.position = _camera.transform.position + _camera.transform.forward * 2;
				transform.LookAt(_camera.transform);
			}
		}

		protected abstract void Initialize();
		
		protected abstract void UpdateMenu();

		public void SetActive(bool active) {
			gameObject.SetActive(active);
			if(active) {
				GetController().SetActiveMenu(this);
				_needsUpdate = true;
			}
		}

		public bool IsActive() { return gameObject.activeSelf; }

		public void FlagUpdate() { _needsUpdate = true; }
		
		protected MenuController GetController() {
			return FindObjectOfType<MenuController>();
		}
	}
}