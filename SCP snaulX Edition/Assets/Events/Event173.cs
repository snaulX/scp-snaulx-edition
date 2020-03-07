using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event173 : MonoBehaviour
{
    GameObject player;
    float timeout = 0;
    GameObject scp173;

    void Start()
    {
        scp173 = GameObject.Find("scp173");
        player = GameObject.Find("player");
    }

    void Update()
    {
        if (timeout > 0)
        {
            timeout = timeout - Time.deltaTime * 80;
        }
        if (player.transform.position == gameObject.transform.position)
        {
            if (timeout < 0) scp173.transform.position = new Vector3(-10, -4.63f, 35);
            else Debug.Log("event not working");
            timeout = 500;
        }
    }
}
