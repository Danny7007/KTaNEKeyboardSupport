using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores information about a button and how to get to it.
/// </summary>
public abstract class ButtonInfo {

	/// <summary>
	/// The key(s) that this button responds to.
	/// </summary>
	public KeySet keys;
	/// <summary>
	/// Obtains the button to be tapped into.
	/// </summary>
	/// <param name="root">The root transform which will be at the top of the search.</param>
	public abstract Transform GetTransform(Transform root);

	public ButtonInfo(KeySet keys)
    {
		this.keys = keys;
    }
	public ButtonInfo(KeyCode key) : this(new KeySet(key)) { }



	/// <summary>
	/// Returns the child of <paramref name="root"/> with name <paramref name="name"/>, or throws a NullReferenceException if no such child can be found.
	/// </summary>
	protected Transform GetChild(Transform root, string name, bool nullPossible)
    {
		if (root.Find(name) == null)
        {
			Debug.Log(nullPossible);
			if (nullPossible)
				return null;
			else throw new NullReferenceException(string.Format("Could not find a child named {0} from root {1}.", name, root.name));
        }
		return root.Find(name);
	}
	protected Transform GetChildRecursive(Transform root, Predicate<Transform> validator, bool nullPossible)
    {
		return GetChildRecursive(new[] { root }, validator, root.name, nullPossible);
    }
	private Transform GetChildRecursive(Transform[] roots, Predicate<Transform> validator, string startingRootName, bool nullPossible)
    {
		List<Transform> tfs = new List<Transform>();
		foreach (Transform root in roots)
        {
			if (validator(root))
				return root;
			foreach (Transform child in root)
				tfs.Add(child);
        }
		if (tfs.Count == 0)
        {
			Debug.Log(nullPossible);
			if (nullPossible)
				return null;
			else throw new NullReferenceException(string.Format("Could not find a child which fits the condition {0} from root {1}.", validator, startingRootName));
        }
		return GetChildRecursive(tfs.ToArray(), validator, startingRootName, nullPossible);
    }
}
