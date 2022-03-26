using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleInfo {

    public readonly string moduleId;
    public readonly ButtonInfo[] buttons;

    public ModuleInfo(string moduleId, params ButtonInfo[] buttons)
    {
        this.moduleId = moduleId;
        this.buttons = buttons;
    }
}
