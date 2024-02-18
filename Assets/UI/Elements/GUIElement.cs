using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Menus {
	/**
	 * Base class for all GUI elements.
	 */
	public abstract class GUIElement : MonoBehaviour {
		
		public List<GUIElement> GetChildren() {
			return (from Transform child in transform select child.GetComponent<GUIElement>() into element where element != null select element).ToList();
		}
		
		public GUIElement GetChild(string name) {
			return GetChildren().FirstOrDefault(child => child.name == name);
		}
		
		public void AddChild(GUIElement child) {
			child.transform.SetParent(transform);
		}
		
		public void RemoveChild(GUIElement child) {
			child.transform.SetParent(null);
		}
		
		public bool HasChild(GUIElement child) {
			return child.transform.IsChildOf(transform);
		}
		
		public void ClearChildren() {
			foreach(GUIElement child in GetChildren()) RemoveChild(child);
		}
		
		public GUIElement GetParent() {
			return transform.parent.GetComponent<GUIElement>();
		}
	}
}