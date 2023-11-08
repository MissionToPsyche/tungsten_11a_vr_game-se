using UnityEngine;

namespace World.Entity.Camera {
	/**
	 * Camera that follows a target object.
	 */
	public class TrackingCamera : MonoBehaviour {
		public GameObject target;
		public Vector3 posOffset = new(0.0f, 0.0f, -5.0f);
		public float minZoom = 1.5f;
		private Quaternion _rotationOffset = Quaternion.identity;
		private Quaternion _originalOrientation;
		private float _zoomAmount;
		private float _zoomSpeed;
		
		private readonly float _rotationSpeed = 3.0f;
		
		public void Start() {
			if(target == null) Debug.LogError("TrackingCamera target is null");
			Update();
		}

		public void Update() {
			//Handle mouse wheel zoom
			var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
			var zoomSpeed = Input.GetKey(KeyCode.LeftShift) ? 10 : 1;
			ZoomCamera(scrollWheel * 10, zoomSpeed);
			
			//Handle zooming
			if(_zoomSpeed != 0) {
				var zoom = _zoomSpeed * Time.deltaTime;
				if(Mathf.Abs(zoom) >= Mathf.Abs(_zoomAmount)) {
					transform.position += transform.forward * _zoomAmount;
					_zoomAmount = 0;
					_zoomSpeed = 0;
				} else {
					transform.position += transform.forward * zoom;
					_zoomAmount -= zoom;
				}
				//Make sure we are not zooming past or into the target
				if(Vector3.Distance(transform.position, target.transform.position) < minZoom) {
					transform.position = target.transform.position + (transform.position - target.transform.position).normalized * minZoom;
					_zoomAmount = 0;
					_zoomSpeed = 0;
				}
			}

			if(target.transform.position - transform.position != Vector3.zero) { //Prevent divide by zero
				_originalOrientation = Quaternion.LookRotation(target.transform.position - transform.position);
			}
			if(Input.GetMouseButton(1)) { //Right mouse button
				var horizontalInput = Input.GetAxis("Mouse X") * _rotationSpeed;
				var verticalInput = Input.GetAxis("Mouse Y") * _rotationSpeed;
				_rotationOffset *= Quaternion.Euler(-verticalInput, horizontalInput, 0f);
				transform.rotation = _originalOrientation * _rotationOffset;
			} else { //Smoothly transition back to original rotation when mouse button is released
				_rotationOffset = Quaternion.Slerp(_rotationOffset, Quaternion.identity, Time.deltaTime * _rotationSpeed);
				transform.rotation = _originalOrientation * _rotationOffset;
			}
			//Handle moving
			transform.position = target.transform.position + posOffset;
		}
		
		public Quaternion GetRotationOffset() { return _rotationOffset; }
		
		/**
		 * Zooms the camera in or out by the given amount, where positive is in and negative is out.
		 * @param zoomAmount The amount to zoom by.
		 * @param zoomSpeed The speed at which to zoom in units per second. Higher values means the camera zooms faster.
		 * If 0, the camera will instantly snap to the new zoom level.
		 */
		public void ZoomCamera(float zoomAmount, float zoomSpeed) {
			_zoomAmount = zoomAmount;
			_zoomSpeed = zoomSpeed;
			if(zoomSpeed == 0) transform.position += transform.forward * zoomAmount;
		}
	}
}