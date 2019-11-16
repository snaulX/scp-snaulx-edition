using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public byte axis;
    public float seconds;
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
        if (seconds <= 0 && seconds != -1)
        {
            Close();
        }
        else
        {
            seconds = seconds - Time.deltaTime * 80;
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
                }
                else
                {
                    audio.Play();
                }
            }
            else
            {
                player = GameObject.FindGameObjectWithTag("scp");
                Debug.Log(player.transform.position + " " + transform.position);
                if (-4 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 4
                && -4 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 4)
                {
                    if (level < SecurityLevel.MTF)
                    {
                        Open();
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
            for (float i = 0; i < 6f; i += 0.001f)
            {
                if (axis == 0) transform.position = new Vector3(x - i, transform.position.y, z);
                else if (axis == 1) transform.position = new Vector3(-x - i, transform.position.y, z);
                else if (axis == 2) transform.position = new Vector3(x, transform.position.y, z - i);
                else transform.position = new Vector3(x, transform.position.y, -z - i);
            }
            seconds = 100;
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
