using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => ExitGame());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ExitGame()
    {
        Application.Quit();
    }
}
