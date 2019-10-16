using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scp173 : MonoBehaviour
{
    Scp scp
    {
        get => GetComponent<Scp>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<AudioSource>());
        GetComponents<AudioSource>()[0].Play();
        if (scp.hp <= 0)
            Destroy(gameObject);
        scp.Kill();
        if (scp.enemy.GetComponent<Player>().hp <= 0) GetComponents<AudioSource>()[1].Play();
    }

    private void OnDestroy()
    {
        Debug.Log("scp 173 is die");
    }
}
