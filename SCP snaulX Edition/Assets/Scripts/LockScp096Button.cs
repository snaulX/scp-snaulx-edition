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
            if (-5 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 5 && Input.GetKey(KeyCode.E))
            {
                Door door = GameObject.Find("door096").GetComponent<Door>();
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
