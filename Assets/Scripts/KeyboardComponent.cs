using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardComponent : MonoBehaviour {

	private KMSelectable attachedSelectable;

	public List<KeyCode> boundKeys;
	private bool held; 

	void Awake () {
		attachedSelectable = GetComponent<KMSelectable>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (KeyCode key in boundKeys)
        {
			if (Input.GetKeyDown(key) && !held)
            {
				held = true;
				attachedSelectable.OnInteract();
            }
			if (Input.GetKeyUp(key) && held)
            {
				held = false;
				attachedSelectable.OnInteractEnded();
            }
        }
	}
}
