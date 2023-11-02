using UnityEngine;

namespace World.Entity.Camera {
	/**
	 * Camera nodes are used to define the camera's position and rotation at certain points in the world.
	 * These are used for the RailCamera to move along a path and change the camera's position and rotation.
	 */
	public class CameraNode : MonoBehaviour {
		
		public float TransitionSpeed = 1.0f;
		
		public Vector3 Position => transform.position;
		
		public Vector3 Rotation => transform.rotation.eulerAngles;
	}
}