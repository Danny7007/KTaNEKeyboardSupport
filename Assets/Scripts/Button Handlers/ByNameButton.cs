using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByNameButton : ButtonInfo
{
    private string _name;
    public ByNameButton(KeySet keys, string name) : base(keys)
    {
        _name = name;
    }
    public ByNameButton(KeyCode key, string name) : this(new KeySet(key), name) { }
    public override Transform GetTransform(Transform root)
    {
        return GetChildRecursive(root, tf => tf.name == _name && tf.GetComponent<KMSelectable>() != null, false);
    }
}
