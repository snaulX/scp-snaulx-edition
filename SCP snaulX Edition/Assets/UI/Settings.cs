using System;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Helper.disabled[0].SetActive(false));
    }
}
