using UnityEngine;

namespace DevTools {
	/**
	 * Utilities for drawing debug shapes in the editor. Call these methods from OnDrawGizmos() or OnDrawGizmosSelected().
	 */
	public class DebugDrawUtil : MonoBehaviour {
		public static void DrawSolidLine(Vector3 start, Vector3 end, Color color) {
			Color oldColor = Gizmos.color;
			Gizmos.color = color;
			Gizmos.DrawLine(start, end);
			Gizmos.color = oldColor;
		}

		public static void DrawArrow(Vector3 position, Vector3 direction, Color color) {
			Color oldColor = Gizmos.color;
			Gizmos.color = color;
			Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + 20, 0) * new Vector3(0, 0, 1);
			Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - 20, 0) * new Vector3(0, 0, 1);
			Gizmos.DrawRay(position, right);
			Gizmos.DrawRay(position, left);
			Gizmos.color = oldColor;
		}

		public static void DrawCircle(Vector3 position, float radius, Color color) {
			Color oldColor = Gizmos.color;
			Gizmos.color = color;
			Gizmos.DrawWireSphere(position, radius);
			Gizmos.color = oldColor;
		}

		public static void DrawCircle(Vector3 position, float radius, int segments, Color color) {
			Color oldColor = Gizmos.color;
			Gizmos.color = color;
			float angle;
			Vector3 start = Vector3.zero;
			Vector3 end = Vector3.zero;
			for(int i = 0; i < segments; ++i) {
				angle = Mathf.Deg2Rad * (i * 360f / segments);
				start = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * radius;
				angle = Mathf.Deg2Rad * ((i + 1) * 360f / segments);
				end = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * radius;
				Gizmos.DrawLine(position + start, position + end);
			}

			Gizmos.color = oldColor;
		}

		public static void DrawCircle(Vector3 position, float radius, int segments, float startAngle, float endAngle,
			Color color) {
			Color oldColor = Gizmos.color;
			Gizmos.color = color;
			float angle = 0f;
			Vector3 start = Vector3.zero;
			Vector3 end = Vector3.zero;
			for(int i = 0; i < segments; ++i) {
				angle = Mathf.Deg2Rad * (i * 360f / segments);
				start = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * radius;
				angle = Mathf.Deg2Rad * ((i + 1) * 360f / segments);
				end = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * radius;
				Gizmos.DrawLine(position + start, position + end);
			}

			Gizmos.color = oldColor;
		}

		public static void DrawSphere(Vector3 position, float radius, Color color) {
			DrawSphere(position, radius, color, false);
		}

		public static void DrawSphere(Vector3 position, float radius, Color color, bool wireFrame) {
			Color oldColor = Gizmos.color;
			Gizmos.color = color;
			if(wireFrame) Gizmos.DrawWireSphere(position, radius);
			else Gizmos.DrawSphere(position, radius);
			Gizmos.color = oldColor;
		}
	}
}