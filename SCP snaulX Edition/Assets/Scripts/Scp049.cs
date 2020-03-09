using UnityEngine;
using System.Collections;

public class Scp049 : MonoBehaviour
{
    Scp scp;

    // Use this for initialization
    void Start()
    {
        scp = GetComponent<Scp>();
        scp.death_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scp.Kill();

    }
}
