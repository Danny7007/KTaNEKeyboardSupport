using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyboardSupportServiceScript : MonoBehaviour {

    public KMBombInfo Bomb;
    KMBombModule[] supportedModsPresentOnBomb;

    void Start()
    {
        Debug.Log("[Keyboard Support Service] Loaded Keyboard Support");
        supportedModsPresentOnBomb = FindObjectsOfType<KMBombModule>()
                                        .Where(m => ModuleData.mods.ContainsKey(m.ModuleType)).ToArray();
        foreach (KMBombModule module in supportedModsPresentOnBomb)
            SetUpComponent(module);
    }

    void SetUpComponent(KMBombModule module)
    {
        Transform obj = module.transform;
        KMSelectable sel = module.GetComponent<KMSelectable>();
        Debug.LogFormat("[Keyboard Support Service] Setting up support for module {0}.", obj.name);
        ModuleInfo info = ModuleData.mods[module.ModuleType];

        ParentSelectable par = obj.gameObject.AddComponent<ParentSelectable>();
        par.AssignSelectables(info);
    }
}
