using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public byte axis;
    public float seconds;
    float x, z;
    public SecurityLevel level;
    public bool Lock;
    public new AudioSource audio;
    
    void Start()
    {
        audio = GameObject.Find("DoorSound").GetComponent<AudioSource>();
        x = transform.position.x;
        z = transform.position.z;
    }
    
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
    }

    public void Close()
    {
        if (!Lock)
        {
            try
            {
                //AudioSource close = GetComponents<AudioSource>()[1];
                //close.PlayOneShot(close.clip);
            }
            catch { }
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }

    public void Open()
    {
        if (!Lock)
        {
            try
            {
                //AudioSource open = GetComponents<AudioSource>()[0];
                //open.PlayOneShot(open.clip);
                if (axis == 0) GetComponent<Animator>().Play("top");
                else if (axis == 1) GetComponent<Animator>().Play("bottom");
                else if (axis == 2) GetComponent<Animator>().Play("left");
                else GetComponent<Animator>().Play("right");
            }
            catch
            {
                //if door haven`t animation
                for (float i = 0; i < 6f; i += 0.001f)
                {
                    //движение двери относительно стартовой позиции персонажа
                    if (axis == 0) transform.position = new Vector3(x - i, transform.position.y, z); //left
                    else if (axis == 1) transform.position = new Vector3(-x - i, transform.position.y, z); //right
                    else if (axis == 2) transform.position = new Vector3(x, transform.position.y, z - i); //top
                    else transform.position = new Vector3(x, transform.position.y, -z - i); //back
                }
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
