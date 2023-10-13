using UnityEngine;

namespace World.Entity.Camera {
	/**
	 * Camera that follows a target object.
	 */
	public class TrackingCamera : MonoBehaviour {
		
		private GameObject target;
		private Vector3 offset;
		
		public TrackingCamera(GameObject target, Vector3 offset) {
			this.target = target;
			this.offset = offset;
		}
		
		public void Start() {
			if(target == null) Debug.LogError("TrackingCamera target is null");
		}

		public void Update() {
			
		}
		
		public GameObject GetTarget() {
			return target;
		}
		
		public void SetTarget(GameObject target) {
			this.target = target;
		}
		
		public Vector3 GetOffset() {
			return offset;
		}
		
		public void SetOffset(Vector3 offset) {
			this.offset = offset;
		}
	}
}