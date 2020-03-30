using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    Dropdown pickItem, operateDoor, closeSomething, exitGame, restart;
    void Start()
    {
        Helper.disabled.Add(GameObject.Find("Canvas"));
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            if (button.name == "Back")
            {
                button.onClick.AddListener(() =>
                {
                    SaveAll();
                    Helper.disabled[0].SetActive(true);
                });
                break;
            }
        }
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
        closeSomething = dropdowns[2];
        closeSomething.value = PlayerPrefs.GetInt("closeSomething");
        exitGame = dropdowns[3];
        exitGame.value = PlayerPrefs.GetInt("exitGame");
        restart = dropdowns[4];
        restart.value = PlayerPrefs.GetInt("restart");
    }
    
    private void SaveAll()
    {
        PlayerPrefs.SetInt("pickItem", pickItem.value);
        PlayerPrefs.SetInt("operateDoor", operateDoor.value);
        PlayerPrefs.SetInt("closeSomething", closeSomething.value);
        PlayerPrefs.SetInt("exitGame", exitGame.value);
        PlayerPrefs.SetInt("restart", restart.value);
        PlayerPrefs.Save();
    }

    private void Update() => SaveAll();
}
