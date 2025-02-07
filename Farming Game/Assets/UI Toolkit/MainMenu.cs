using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public partial class MainMenu : MonoBehaviour
{
    VisualElement main = null;
    VisualElement settings = null;

    VisualElement root;

    private static object GetDebuggerDisplay()
    {
        throw new NotImplementedException();
    }

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    void Start()
    {

        Button settingsbutton = root.Q<Button>("settings");
        Button Exitbutton = root.Q<Button>("Exit To Desktop");

        settings = root.Q<VisualElement>("settingbackground");
        main = root.Q<VisualElement>("Exit To Main Menu");

        Playbutton.RegisterCallback<ClickEvent>(x => settings.style.display = DisplayStyle.None);
        SettingsButton.RegisterCallback<ClickEvent>(x => settings.style.display = DisplayStyle.Flex);




    }

}

    