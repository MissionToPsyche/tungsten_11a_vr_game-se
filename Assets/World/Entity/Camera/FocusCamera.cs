using Controller.Input;
using Controller.Input.Interaction;
using UnityEngine;

namespace World.Entity.Camera {
	/**
	 * Camera that can be focused on a specific object.
	 */
	public class FocusCamera : ObjectFocuser {
		
		public GameObject target;
		
		private bool _focused;
		private Vector3 _originalPosition;
		private Quaternion _originalRotation;
		
		void Update() {
			if(_focused) return;
			//Handle input like normal
			if(InputManager.GetMouseInput().GetButton(1)) {
				Vector3 lookPosition = InputManager.GetLookPosition();
				transform.LookAt(lookPosition);
			}
		}

		protected override void Focus(bool focused) {
			_focused = focused;
			if(focused) { //Move the camera in front of the object and look at it
				_originalPosition = transform.position;
				_originalRotation = transform.rotation;
				
				transform.position = target.transform.position + target.transform.forward * 2;
				transform.LookAt(target.transform);
			} else { //Reset the camera to its original position
				transform.position = _originalPosition;
				transform.rotation = _originalRotation;
			}
		}
	}
}