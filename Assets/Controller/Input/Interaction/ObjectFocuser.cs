using UnityEngine;

namespace Controller.Input.Interaction {
	
	/**
	* Interface for objects that can be highlighted / focused on when hovered over using the mouse or other input.
	*/
	public abstract class ObjectFocuser : MonoBehaviour {
		
		private Collider _collider;
		private float _hoverTime;

		void Start() {
			_collider = GetComponent<Collider>();
		}
		
		void Update() {
			//Todo: IDE says that comparing to null is "expensive" and should be avoided, but I don't know how else to do this
			if(_collider != null && _collider.bounds.Contains(InputManager.GetLookPosition())) {
				_hoverTime += Time.deltaTime;
				if(_hoverTime >= 5f) Focus(true);
			} else {
				_hoverTime = 0f;
				Focus(false);
			}
		}

		protected abstract void Focus(bool focused);
	}
}