using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyboardSupportServiceScript : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMGameInfo GameInfo;
    private KMBombModule[] supportedModsPresentOnBomb;

    void Start()
    {

        Debug.Log("[Keyboard Support Service] Loaded Keyboard Support");
        if (Application.isEditor)
            ConfigureComponentsOnBomb();
        else GameInfo.OnStateChange += st => { if (st == KMGameInfo.State.Gameplay) StartCoroutine(LoadComponents()); };
    }
    IEnumerator LoadComponents()
    {
        yield return new WaitUntil(() => Bomb.IsBombPresent() && Bomb.GetModuleNames().Count() > 0);
        ConfigureComponentsOnBomb();
    }
    void ConfigureComponentsOnBomb()
    {
        
        Debug.Log("[Keyboard Support Service] Bomb loaded... configuring supports.");
        supportedModsPresentOnBomb = FindObjectsOfType<KMBombModule>()
                                        .Where(m => ModuleData.mods.ContainsKey(m.ModuleType)).ToArray();
        if (supportedModsPresentOnBomb.Length == 0)
            Debug.Log("[Keyboard Support Service] No keyboard-supported mods on the bomb.");
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
