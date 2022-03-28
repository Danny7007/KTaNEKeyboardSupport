using System;
using System.Linq;
using UnityEngine;

public class SelectableChildIndexerButton : ButtonInfo
{
    private readonly int _index;
    private readonly bool _eliminateNull;

    public SelectableChildIndexerButton(KeyCode[] keys, int index, bool eliminateNull=false) : base(keys)
    {
        _index = index;
        _eliminateNull = eliminateNull;
    }

    public override Transform GetTransform(Transform root)
    {
        KMSelectable sel = root.GetComponent<KMSelectable>();
        if (sel == null)
            throw new MissingComponentException("Cannot find KMSelectable component on root Transform.");
        KMSelectable[] children = sel.Children;
        if (_eliminateNull)
            children = children.Where(x => x != null).ToArray();
        if (_index >= children.Length || _index < 0)
            throw new IndexOutOfRangeException(string.Format("Entered index {0} extends out of the bounds of the children array [0-{1}].", _index, children.Length - 1));
        return children[_index].transform;
    }
}
