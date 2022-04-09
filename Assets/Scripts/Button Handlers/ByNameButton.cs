using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByNameButton : ButtonInfo
{
    private string _name;
    public ByNameButton(KeyCode[] keys, string name) : base(keys)
    {
        _name = name;
    }
    public ByNameButton(KeyCode key, string name) : this(new[] { key }, name) { }
    public override Transform GetTransform(Transform root)
    {
        return GetChildRecursive(root, _name, tf => tf.GetComponent<KMSelectable>() != null);
    }
}
