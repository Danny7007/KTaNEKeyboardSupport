using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ModuleData
{
    public static Dictionary<string, ModuleInfo> mods = new ModuleInfo[]
    {
        new ModuleInfo("testMod",
            new ByNameButton(KeyCode.Alpha1, "Btn1"),
            new DirectPathButton(KeyCode.Alpha2, "Layer1", "Btn2"),
            new SelectableChildIndexerButton(KeyCode.Alpha3, 2)),

        new ModuleInfo("Emoji Math",
            new ByNameButton(new[] { KeyCode.Alpha0, KeyCode.Keypad0 }, "Button0"),
            new ByNameButton(new[] { KeyCode.Alpha1, KeyCode.Keypad1 }, "Button1"),
            new ByNameButton(new[] { KeyCode.Alpha2, KeyCode.Keypad2 }, "Button2"),
            new ByNameButton(new[] { KeyCode.Alpha3, KeyCode.Keypad3 }, "Button3"),
            new ByNameButton(new[] { KeyCode.Alpha4, KeyCode.Keypad4 }, "Button4"),
            new ByNameButton(new[] { KeyCode.Alpha5, KeyCode.Keypad5 }, "Button5"),
            new ByNameButton(new[] { KeyCode.Alpha6, KeyCode.Keypad6 }, "Button6"),
            new ByNameButton(new[] { KeyCode.Alpha7, KeyCode.Keypad7 }, "Button7"),
            new ByNameButton(new[] { KeyCode.Alpha8, KeyCode.Keypad8 }, "Button8"),
            new ByNameButton(new[] { KeyCode.Alpha9, KeyCode.Keypad9 }, "Button9"),
            new ByNameButton(new[] { KeyCode.Minus, KeyCode.KeypadMinus }, "MinusButton"),
            new ByNameButton(new[] { KeyCode.Return, KeyCode.KeypadEnter, KeyCode.Equals, KeyCode.KeypadEquals }, "EnterButton")
            ),

        new ModuleInfo("alphabet",
            GetAlphabet(true)),

        //Switches
        new ModuleInfo("switchModule",
            new SelectableChildIndexerButton(KeyCode.Alpha1, 0),
            new SelectableChildIndexerButton(KeyCode.Alpha2, 1),
            new SelectableChildIndexerButton(KeyCode.Alpha3, 2),
            new SelectableChildIndexerButton(KeyCode.Alpha4, 3),
            new SelectableChildIndexerButton(KeyCode.Alpha5, 4)
            ),
        
        new ModuleInfo("TwoBits",
            new TextMeshGrabberButton(KeyCode.B, "B"),
            new TextMeshGrabberButton(KeyCode.C, "C"),
            new TextMeshGrabberButton(KeyCode.D, "D"),
            new TextMeshGrabberButton(KeyCode.E, "E"),
            new TextMeshGrabberButton(KeyCode.G, "G"),
            new TextMeshGrabberButton(KeyCode.K, "K"),
            new TextMeshGrabberButton(KeyCode.P, "P"),
            new TextMeshGrabberButton(KeyCode.V, "V"),
            new TextMeshGrabberButton(KeyCode.Z, "Z"),
            new TextMeshGrabberButton(KeyCode.KeypadEnter, "SUBMIT"),
            new TextMeshGrabberButton(new[] { KeyCode.Space, KeyCode.LeftShift, KeyCode.RightShift }, "QUERY")
            ),



    }.ToDictionary(inf => inf.moduleId);

    private static TextMeshGrabberButton[] GetAlphabet(bool nullPossible = false, params string[] path)
    {
        return Enumerable.Range(0, 26).Select(ix => new TextMeshGrabberButton(KeyCode.A + ix, (KeyCode.A + ix).ToString(), nullPossible, path)).ToArray();
    }
}
