using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardComponent : MonoBehaviour {

	public KMSelectable attachedSelectable;
	private KeyboardSupportScript parentService;
	void Awake () {
		attachedSelectable = GetComponent<KMSelectable>();
		parentService = FindObjectOfType<KeyboardSupportScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
