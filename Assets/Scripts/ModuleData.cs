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
            new ByNameButton(KeySet.zero, "Button0"),
            new ByNameButton(KeySet.one, "Button1"),
            new ByNameButton(KeySet.two, "Button2"),
            new ByNameButton(KeySet.three, "Button3"),
            new ByNameButton(KeySet.four, "Button4"),
            new ByNameButton(KeySet.five, "Button5"),
            new ByNameButton(KeySet.six, "Button6"),
            new ByNameButton(KeySet.seven, "Button7"),
            new ByNameButton(KeySet.eight, "Button8"),
            new ByNameButton(KeySet.nine, "Button9"),
            new ByNameButton(new KeySet(KeyCode.Minus, KeyCode.KeypadMinus), "MinusButton"),
            new ByNameButton(KeySet.enter + KeyCode.Equals + KeyCode.KeypadEquals, "EnterButton")
            ),

        new ModuleInfo("alphabet",
            GetAlphabet(true)
        ),

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
            new TextMeshGrabberButton(KeyCode.T, "T"),
            new TextMeshGrabberButton(KeyCode.V, "V"),
            new TextMeshGrabberButton(KeyCode.Z, "Z"),
            new TextMeshGrabberButton(KeySet.enter + KeyCode.S, "SUBMIT"),
            new TextMeshGrabberButton(KeySet.shift + KeyCode.Space + KeyCode.Q, "QUERY")
            ),



    }.ToDictionary(inf => inf.moduleId);

    private static TextMeshGrabberButton[] GetAlphabet(bool nullPossible, params string[] path)
    {
        return Enumerable.Range(0, 26).Select(ix => new TextMeshGrabberButton(KeyCode.A + ix, (KeyCode.A + ix).ToString(), nullPossible, path)).ToArray();
    }
}
