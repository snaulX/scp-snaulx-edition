using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    
    void Start()
    {
        Dropdown[] dropdowns = GetComponentsInChildren<Dropdown>();
        Type keycode = typeof(KeyCode);
        foreach (Dropdown dropdown in dropdowns)
        {
            List<string> captions = new List<string>();
            dropdown.ClearOptions();
            foreach (KeyCode code in Enum.GetValues(keycode).Cast<KeyCode>()) captions.Add(code.ToString());
            dropdown.AddOptions(captions);
        }
        Dropdown pickItem = dropdowns[0];//, operateDoor = dropdowns[1];
        pickItem.value = PlayerPrefs.GetInt("pickItem");
        pickItem.onValueChanged.AddListener((value) => PlayerPrefs.SetInt("pickItem", value));
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
}
