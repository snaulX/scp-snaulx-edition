using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scp173 : MonoBehaviour
{
    Scp scp
    {
        get => GetComponent<Scp>();
        set => GetComponent<Scp>();
    }
    AudioSource walk;
    // Start is called before the first frame update
    void Start()
    {
        walk = GetComponents<AudioSource>()[0];
        scp.death_audio = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (scp.hp <= 0)
            Destroy(gameObject);
        scp.Kill();
    }

    private void OnDestroy()
    {
        Debug.Log("scp 173 is die");
    }
}
