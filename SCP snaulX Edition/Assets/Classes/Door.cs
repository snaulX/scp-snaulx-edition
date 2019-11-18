using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public byte axis;
    public float seconds;
    float x, z;
    public SecurityLevel level;
    public bool Lock;
    new AudioSource audio;
    private bool player_can_open = false;
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
                && -4 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 4)
            {
                player_can_open = true;
                if (Input.GetKeyDown(KeyCode.E))
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
            }
            else
            {
                player_can_open = false;
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

    private void OnGUI()
    {
        if (player_can_open)
        {
            GUI.DrawTexture(new Rect(400, 400, 60, 60), GameObject.Find("player").GetComponent<Main>().handsymbol);
        }
    }
}
