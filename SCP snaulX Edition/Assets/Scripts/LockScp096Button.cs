using UnityEngine;
using System.Collections;
using System;

public class LockScp096Button : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (-3 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 3
                && -3 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 3
                && Input.GetKeyDown(KeyCode.E))
            {
                Door door = GameObject.Find("door096").GetComponent<Door>();
                GetComponent<AudioSource>().Play();
                if (door.Lock) door.Unlock();
                else door.Lockdown();
            }
        }
        catch (NullReferenceException)
        {
            //ничего не делать
        }
    }
}
