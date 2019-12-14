using UnityEngine;
using System.Collections;

public class Scp049 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float bombButton = GameObject.Find("bombbutton").GetComponent<BombButton>().seconds;
        if (bombButton > 0) GetComponent<AudioSource>().Play();
        else if (bombButton < 0 && bombButton != -100) GetComponents<AudioSource>()[1].Play();
    }
}
