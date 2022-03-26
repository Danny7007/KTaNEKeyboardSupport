using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Placed on each selectable that has support and accepts input whenever the mod is selected.
/// </summary>
public class ChildSelectable : MonoBehaviour {

	/// <summary>
	/// The key(s) that this button responds to.
	/// </summary>
	public List<KeyCode> keys { get; set; }
	/// <summary>
	/// The parent selectable, used for detecting when to fire.
	/// </summary>
	public ParentSelectable parent { get; set; }

	/// <summary>
	/// The button to be pressed.
	/// </summary>
	private KMSelectable _selectable;

	void Start() {
		_selectable = GetComponent<KMSelectable>();
    }
	void Update () {

		//Only check if the parent selectable is in focus.
		if (parent.isSelected)
        {
			//If the key is just depressed, press this button.
			if (keys.Any(key => Input.GetKeyDown(key)))
				_selectable.OnInteract();
			//If the key is just released, release this button.
			if (keys.Any(key => Input.GetKeyUp(key)))
				_selectable.OnInteractEnded();
        }
	}
}
