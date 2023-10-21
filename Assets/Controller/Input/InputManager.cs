using System;
using UnityEngine;

namespace Controller.Input {
	public class InputManager : MonoBehaviour {

		private static InputManager _instance;
		private MouseInput _mouseInput;
		private KeyboardInput _keyboardInput;
		
		void Start() {
			_instance = this;
			_mouseInput = new MouseInput();
			_keyboardInput = new KeyboardInput();
		}
		
		public static Vector3 GetLookPosition() {
			//Todo: Support controllers and VR look, but for now just use mouse
			return _instance._mouseInput.GetPosition();
		}
		
		public static MouseInput GetMouseInput() {
            return _instance._mouseInput;
        }
	}
	
	public struct MouseInput {
		public Vector3 GetPosition() {
			return UnityEngine.Input.mousePosition;
		}
		
		public bool GetButton(int button) {
			return UnityEngine.Input.GetMouseButton(button);
		}
		
		public float GetScroll() {
			return UnityEngine.Input.mouseScrollDelta.y;
		}
	}

	public struct KeyboardInput {
		public bool GetKey(KeyCode key) {
			return UnityEngine.Input.GetKey(key);
		}
	}

	public struct ControllerInput {
		/* Todo: Implement controller input
		public Vector2 GetLeftStick() { //Todo: Figure out how to differentiate between left and right sticks
			return new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
		}

		public Vector2 GetRightStick() {
			return new Vector2(UnityEngine.Input.GetAxis("Mouse X"), UnityEngine.Input.GetAxis("Mouse Y"));
		}
		*/
	}
}