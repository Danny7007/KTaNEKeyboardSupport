using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModScript : MonoBehaviour {

	public KMSelectable[] btns;

	// Use this for initialization
	void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
			int ix = i;
			btns[ix].OnInteract += delegate () { Debug.Log("Pressed btn " + (ix + 1)); return false; };
			btns[ix].OnInteractEnded += delegate () { Debug.Log("Released btn " + (ix + 1)); };

        }
    }
	
}
