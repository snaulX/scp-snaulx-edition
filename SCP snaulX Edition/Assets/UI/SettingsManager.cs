using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    Dropdown pickItem, operateDoor;
    void Start()
    {
        Helper.disabled.Add(GameObject.Find("Canvas"));
        Dropdown[] dropdowns = GetComponentsInChildren<Dropdown>();
        foreach (Dropdown dropdown in dropdowns)
        {
            List<string> captions = new List<string>();
            dropdown.ClearOptions();
            for (int i = 0; i < Helper.keyCodes.Count; i++) captions.Add(Helper.keyCodes[i].ToString());
            dropdown.AddOptions(captions);
        }
        pickItem = dropdowns[0];
        pickItem.value = PlayerPrefs.GetInt("pickItem");
        operateDoor = dropdowns[1];
        operateDoor.value = PlayerPrefs.GetInt("operateDoor");
    }
    
    private void Update()
    {
        PlayerPrefs.SetInt("pickItem", pickItem.value);
        PlayerPrefs.SetInt("operateDoor", operateDoor.value);
        PlayerPrefs.Save();
        if (Input.GetButton("Cancel"))
        {
            Helper.disabled[0].SetActive(true);
        }
    }
}
