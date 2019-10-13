using UnityEngine;
using System.Collections;
using System;

public class LockScp173Button : MonoBehaviour
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
            GameObject player = GameObject.Find("player");
            if (-3 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 3 
                && -3 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 3
                && Input.GetKey(KeyCode.E))
            {
                Door[] doors = GameObject.Find("big-door").GetComponentsInChildren<Door>();
                foreach (Door door in doors)
                {
                    if (door.Lock) door.Unlock();
                    else door.Lockdown();
                }
            }
        }
        catch (NullReferenceException)
        {
            //ничего не делать
        }
    }
}
