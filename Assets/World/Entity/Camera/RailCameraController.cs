using UnityEngine;

namespace World.Entity.Camera {
	/**
	 * A type of tracking camera that automatically moves along a path at a set speed.
	 */
	public class RailCamera : TrackingCamera {

		public RailCamera(GameObject target, Vector3 offset, Vector3[] path, float speed) : base(target, offset) {
			
		}

		new void Start() {
			
		}

		new void Update() { }
	}
}