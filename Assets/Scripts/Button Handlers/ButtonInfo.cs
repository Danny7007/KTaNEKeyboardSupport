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
	public List<KeyCode> keys;
	/// <summary>
	/// Obtains the button to be tapped into.
	/// </summary>
	/// <param name="root">The root transform which will be at the top of the search.</param>
	public abstract Transform GetTransform(Transform root);

	/// <summary>
	/// Returns the child of <paramref name="root"/> with name <paramref name="name"/>, or throws a NullReferenceException if no such child can be found.
	/// </summary>
	protected Transform GetChild(Transform root, string name)
    {
		if (root.Find(name) == null)
			throw new NullReferenceException(string.Format("Could not find a child named {0} from root {1}.", name, root.name));
		return root.Find(name);
	}
	protected Transform GetChildRecursive(Transform root, string name)
    {
		return GetChildRecursive(new[] { root }, name, x => true, root.name);
    }
	protected Transform GetChildRecursive(Transform root, string name, Predicate<Transform> validator)
    {
		return GetChildRecursive(new[] { root }, name, validator, root.name);
    }
	private Transform GetChildRecursive(Transform[] roots, string name, Predicate<Transform> validator, string startingRootName)
    {
		List<Transform> tfs = new List<Transform>();
		foreach (Transform root in roots)
        {
			if ((name == null || root.Find(name) != null) && validator(root.Find(name)))
				return root.Find(name);
			foreach (Transform child in root)
				tfs.Add(child);
        }
		if (tfs.Count == 0)
			throw new NullReferenceException(string.Format("Could not find a child named {0} from root {1}.", name, startingRootName));
		return GetChildRecursive(tfs.ToArray(), name, validator, startingRootName);
    }
}
