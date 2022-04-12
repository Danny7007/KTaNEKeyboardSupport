using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeySet : IEnumerable<KeyCode>, IEquatable<KeySet>
{
    #region Constants
    public static readonly KeySet shift = new KeySet(KeyCode.LeftShift, KeyCode.RightShift);
    public static readonly KeySet enter = new KeySet(KeyCode.KeypadEnter, KeyCode.Return);
    public static readonly KeySet zero = new KeySet(KeyCode.Alpha0, KeyCode.Keypad0);
    public static readonly KeySet one = new KeySet(KeyCode.Alpha1, KeyCode.Keypad1);
    public static readonly KeySet two = new KeySet(KeyCode.Alpha2, KeyCode.Keypad2);
    public static readonly KeySet three = new KeySet(KeyCode.Alpha3, KeyCode.Keypad3);
    public static readonly KeySet four = new KeySet(KeyCode.Alpha4, KeyCode.Keypad4);
    public static readonly KeySet five = new KeySet(KeyCode.Alpha5, KeyCode.Keypad5);
    public static readonly KeySet six = new KeySet(KeyCode.Alpha6, KeyCode.Keypad6);
    public static readonly KeySet seven = new KeySet(KeyCode.Alpha7, KeyCode.Keypad7);
    public static readonly KeySet eight = new KeySet(KeyCode.Alpha8, KeyCode.Keypad8);
    public static readonly KeySet nine = new KeySet(KeyCode.Alpha9, KeyCode.Keypad9);
    public static readonly KeySet up = new KeySet(KeyCode.W, KeyCode.UpArrow, KeyCode.Keypad8);
    public static readonly KeySet right = new KeySet(KeyCode.D, KeyCode.RightArrow, KeyCode.Keypad6);
    public static readonly KeySet down = new KeySet(KeyCode.S, KeyCode.DownArrow, KeyCode.Keypad2);
    public static readonly KeySet left = new KeySet(KeyCode.A, KeyCode.LeftArrow, KeyCode.Keypad4);
    #endregion

    private List<KeyCode> _keys;

    public KeySet(params KeyCode[] keys)
    {
        _keys = keys.ToList();
    }
    public KeySet(IEnumerable<KeyCode> keys) : this(keys.ToArray()){ }

    public IEnumerator<KeyCode> GetEnumerator()
    { return _keys.GetEnumerator(); }

    IEnumerator IEnumerable.GetEnumerator()
    { return GetEnumerator(); }

    public static KeySet operator +(KeySet a, KeySet b) { return new KeySet(a.Concat(b)); }
    public static KeySet operator +(KeySet set, KeyCode addedKey) { return new KeySet(set.Concat(new[] { addedKey })); }

    public override bool Equals(object obj)
    {
        return obj is KeySet && Equals(obj as KeySet);
    }

    public bool Equals(KeySet other)
    {
        return this._keys.Count == other._keys.Count && _keys.SequenceEqual(other._keys);
    }

    public override string ToString()
    {
        return _keys.Join("|");
    }

    public override int GetHashCode()
    {
        return _keys.Aggregate(0, (hash, k) => hash ^ k.GetHashCode());
    }
}
