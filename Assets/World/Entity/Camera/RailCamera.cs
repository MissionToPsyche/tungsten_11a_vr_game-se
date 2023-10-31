using UnityEngine;

namespace World.Entity.Camera {
	/**
	* A camera that follows a set of points smoothly. Assign points in the inspector, and the script will create a smooth
	* path between them for the camera to follow.
	*/
	public class RailCamera : MonoBehaviour {
		public GameObject[] points;
		public float smoothness = 0.5f;
		public bool loop = true;
		public float speed = 1.0f; //Negative speed will reverse the path
		private Vector3[] _rawCoords;

		private void Start() { }

		private void Update() { }

		private void SmoothPoints() {
			_rawCoords = new Vector3[points.Length];
			for(int i = 0; i < points.Length; i++) {
				_rawCoords[i] = points[i].transform.position;
			}

			for(int i = points.Length; i < _rawCoords.Length; i++) {
				_rawCoords[i] = Vector3.Lerp(_rawCoords[i - 1], _rawCoords[0], ((float)i / _rawCoords.Length));
			}
		}
	}
}