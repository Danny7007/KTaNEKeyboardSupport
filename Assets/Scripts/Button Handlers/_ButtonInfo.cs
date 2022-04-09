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
	public KeyCode[] keys;
	/// <summary>
	/// Obtains the button to be tapped into.
	/// </summary>
	/// <param name="root">The root transform which will be at the top of the search.</param>
	public abstract Transform GetTransform(Transform root);

	public ButtonInfo(KeyCode[] keys)
    {
		this.keys = keys;
    }
	public ButtonInfo(KeyCode key) : this(new[] { key }) { }



	/// <summary>
	/// Returns the child of <paramref name="root"/> with name <paramref name="name"/>, or throws a NullReferenceException if no such child can be found.
	/// </summary>
	protected Transform GetChild(Transform root, string name, bool nullPossible = false)
    {
		if (root.Find(name) == null && !nullPossible)
			throw new NullReferenceException(string.Format("Could not find a child named {0} from root {1}.", name, root.name));
		return root.Find(name);
	}
	protected Transform GetChildRecursive(Transform root, string name, bool nullPossible = false)
    {
		return GetChildRecursive(new[] { root }, name, x => true, root.name, nullPossible);
    }
	protected Transform GetChildRecursive(Transform root, string name, Predicate<Transform> validator, bool nullPossible = false)
    {
		return GetChildRecursive(new[] { root }, name, validator, root.name, nullPossible);
    }
	private Transform GetChildRecursive(Transform[] roots, string name, Predicate<Transform> validator, string startingRootName, bool nullPossible)
    {
		List<Transform> tfs = new List<Transform>();
		foreach (Transform root in roots)
        {
			if ((name == null || root.Find(name) != null) && validator(root.Find(name)))
				return root.Find(name);
			foreach (Transform child in root)
				tfs.Add(child);
        }
		if (tfs.Count == 0 && !nullPossible)
			throw new NullReferenceException(string.Format("Could not find a child named {0} from root {1}.", name, startingRootName));
		return GetChildRecursive(tfs.ToArray(), name, validator, startingRootName, nullPossible);
    }
}
