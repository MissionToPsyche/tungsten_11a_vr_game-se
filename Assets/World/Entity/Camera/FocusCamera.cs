using Controller.Input;
using Controller.Input.Interaction;
using UnityEngine;

namespace World.Entity.Camera {
	/**
	 * Camera that can be focused on a specific object.
	 */
	public class FocusCamera : MonoBehaviour {

		private UnityEngine.Camera _camera;
		private float _focusTimer = 5.0f;
		private bool _isFocused;

		private void Start() {
			_camera = GetComponent<UnityEngine.Camera>();
		}
		
		private void Update() {
			GameObject focusTarget = GetFocusTarget();
			if(focusTarget != null) {
				//Have we been focusing on this target for at least 5 seconds?
				_focusTimer -= Time.deltaTime;
				if(_focusTimer <= 0) {
					_isFocused = true;
					FocusOn(focusTarget);
				}
			} else if(_isFocused) {
				//We were focused, but now we're not, so reset the timer and position
				//Todo
			}
		}

		protected GameObject GetFocusTarget() {
			Ray ray = _camera.ScreenPointToRay(InputManager.GetLookPosition());
			if(Physics.Raycast(ray, out var hit)) {
				if(hit.transform.gameObject.GetComponent<ObjectFocuser>() != null) return hit.transform.gameObject;
			}
			return null;
		}

		
		protected void FocusOn(GameObject target) {
			//Look at the target, then zoom in slightly
			Vector3 targetPosition = target.transform.position;
			Vector3 cameraPosition = _camera.transform.position;
			_camera.transform.LookAt(targetPosition);
			_camera.transform.position = Vector3.Slerp(cameraPosition, targetPosition, 0.5f);
		}

		/*
		public new UnityEngine.Camera camera;
		public float focusTime = 3.0f;
		public float focusDistance = 2.0f;

		private Transform _focusTarget;
		private Vector3 _originalPosition;
		private Quaternion _originalRotation;
		private float _timer;

		private void Update() {
			Ray ray = camera.ScreenPointToRay(InputManager.GetLookPosition());
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				if(hit.transform.gameObject.GetComponent<ObjectFocuser>() != null) {
					if(hit.transform != _focusTarget) {
						_focusTarget = hit.transform;
						_timer = Time.time;
					} else if(Time.time - _timer > focusTime) {
						_originalPosition = camera.transform.position;
						_originalRotation = camera.transform.rotation;
						Vector3 focusPosition = _focusTarget.position - camera.transform.forward * focusDistance;
						camera.transform.position =
							Vector3.Slerp(camera.transform.position, focusPosition, Time.deltaTime);
						camera.transform.LookAt(_focusTarget.position);
					}
				} else Unfocus();
			} else Unfocus();
		}

		private void Unfocus() {
			if(camera.transform.position != _originalPosition) {
				camera.transform.position = Vector3.Slerp(camera.transform.position, _originalPosition, Time.deltaTime);
				camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, _originalRotation, Time.deltaTime);
			}
			_focusTarget = null;
			_timer = 0;
		}
		*/
	}
}