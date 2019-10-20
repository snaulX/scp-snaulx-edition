using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public byte seconds, axis;
    float x, z;
    public SecurityLevel level;
    public bool Lock;
    new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("DoorSound").GetComponent<AudioSource>();
        x = transform.position.x;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (seconds == 0)
        {
            Close();
        }
        else
        {
            seconds--;
        }
        try
        {
            GameObject player = GameObject.Find("player");
            if (-4 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 4
                && -4 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 4
                && Input.GetKeyDown(KeyCode.E))
            {
                if (player.GetComponent<Player>().level >= level)
                {
                    Open();
                    seconds = 255;
                }
                else
                {
                    audio.Play();
                }
            }
            else
            {
                player = GameObject.FindGameObjectWithTag("scp");
                if (-5 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 5
                && -5 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 5)
                {
                    if (level < SecurityLevel.MTF)
                    {
                        Open();
                        seconds = 255;
                    }
                }
            }
        }
        catch (NullReferenceException)
        {
            //лол почему
        }
    }

    public void Close()
    {
        if (!Lock)
        {
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }

    public void Open()
    {
        if (!Lock)
        {
            for (float i = 0; i < 5.4f; i += 0.001f)
            {
                if (axis == 0) transform.position = new Vector3(x - i, transform.position.y, z);
                else if (axis == 1) transform.position = new Vector3(-x - i, transform.position.y, z);
                else if (axis == 2) transform.position = new Vector3(x, transform.position.y, z - i);
                else transform.position = new Vector3(x, transform.position.y, -z - i);
            }
        }
    }

    public void Unlock()
    {
        Lock = false;
        Open();
    }
    public void Lockdown()
    {
        Lock = true;
        Close();
    }
}
