using UnityEngine;

namespace World.Entity.Camera {
	
	/**
	 * Interface for controlling cameras. Rather than extend the camera object (can't anyways its a sealed class),
	 * we can just implement this interface and then add the camera as a component to the object and control it that way.
	 */
	public interface ICameraController {
		public void Start() {
			
		}

		// Update is called once per frame
		public void Update() { }
	}
}