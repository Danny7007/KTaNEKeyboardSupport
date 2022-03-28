using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Finds a button by searching for a given string within a child TextMesh
/// </summary>
public class TextMeshGrabberButton : ButtonInfo {

    /// <summary>
    /// A series of Transform names to search down to find a starting point for the TextMesh search.
    /// </summary>
    private readonly string[] _path;
    private readonly string _targetLabel;

    /// <summary>
    /// Creates a new TextMeshGrabberButton with the given path (starting from the children of the parent selectable).
    /// </summary>
    /// <exception cref="ArgumentException">The path length is equal to zero.</exception>
    public TextMeshGrabberButton(KeyCode[] keys, string targetLabel, params string[] path) : base(keys)
    {
        if (path.Length == 0)
            throw new ArgumentException("Path length cannot be zero.");
        _path = path;
        _targetLabel = targetLabel;
    }

    public override Transform GetTransform(Transform root)
    {
        Transform startingTransform = root;
        foreach (string pathItem in _path)
            startingTransform = GetChild(startingTransform, pathItem);

        Transform foundLabel = GetChildRecursive(startingTransform, null, tf =>
                                tf.GetComponent<TextMesh>() != null &&
                                tf.GetComponent<TextMesh>().text == _targetLabel);
        
        Transform selectable = foundLabel;
        do selectable = selectable.parent;
        while (selectable.GetComponent<KMSelectable>() == null);

        return selectable;
    }
}
