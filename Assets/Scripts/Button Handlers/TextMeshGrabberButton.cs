using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Finds a button by searching for a given string within a child TextMesh
/// </summary>
public class TextMeshGrabberButton : ButtonInfo {

    /// <summary>
    /// A series of Transform names to search down to find a starting point for the TextMesh search.
    /// </summary>
    private readonly string[] _path;
    public readonly string _targetLabel;
    private readonly bool _nullPossible;

    /// <summary>
    /// Creates a new TextMeshGrabberButton with the given path (starting from the children of the parent selectable).
    /// </summary>
    /// <exception cref="ArgumentException">The path length is equal to zero.</exception>
    public TextMeshGrabberButton(KeySet keys, string targetLabel, bool nullPossible = false, params string[] path) : base(keys)
    { 
        _path = path;
        _targetLabel = targetLabel;
    }
    public TextMeshGrabberButton(KeyCode key, string targetLabel, bool nullPossible = false, params string[] path) 
        : this(new KeySet(key), targetLabel, nullPossible, path) { }

    public override Transform GetTransform(Transform root)
    {
        Transform startingTransform = root;
        foreach (string pathItem in _path)
            startingTransform = GetChild(startingTransform, pathItem, _nullPossible);

        Transform foundLabel = GetChildRecursive(startingTransform, 
                                tf => (tf.GetComponent<TextMesh>() != null && tf.GetComponent<TextMesh>().text.ToUpperInvariant() == _targetLabel.ToUpperInvariant()), 
                                _nullPossible);
        
        Transform selectable = foundLabel;
        while (selectable.GetComponent<KMSelectable>() == null && selectable != null)
        {
            if (selectable.GetComponent<KMSelectable>() != null)
                return selectable;
            foreach (Transform sibling in selectable.parent)
                if (sibling.GetComponent<KMSelectable>() != null)
                    return sibling;
            selectable = selectable.parent;
        }
        return null;
    }
}
