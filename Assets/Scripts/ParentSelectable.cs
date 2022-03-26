using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Component placed on the modules that have support.
/// </summary>
public class ParentSelectable : MonoBehaviour {

    /// <summary>
    /// The KMSelectable component attached to the module.
    /// </summary>
	private KMSelectable _modSelectable;
    /// <summary>
    /// Stores whether or not this module is currently selected.
    /// Used by child scripts to determine when to accept input.
    /// </summary>
    public bool isSelected { get; private set; }

	void Start()
    {
        //Grabs the selectable component from the mod.
        _modSelectable = GetComponent<KMSelectable>();

        //Connects the isSelected property to the focus state of the module.
        _modSelectable.OnFocus += () => isSelected = true;
        _modSelectable.OnDefocus += () => isSelected = false;

        //If we are in Unity, OnFocus is never called, and so we make it constantly enabled here.
        if (Application.isEditor)
            isSelected = true;
    }

    public void AssignSelectables(ButtonInfo[] infos)
    {

    }
}
