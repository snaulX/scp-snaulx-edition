using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BombButton : MonoBehaviour
{
    public float seconds;
    private bool player_can_take = false;

    public float fps
    {
        get => GameObject.Find("player").GetComponent<Main>().fps;
    }
    // Use this for initialization
    void Start()
    {
        seconds = -100f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");
        AudioSource[] audio = GetComponents<AudioSource>();
        if (seconds == -100f)
        {
            if (-2 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 2
                && -2 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 2)
            {
                player_can_take = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject[] doorobjs = GameObject.FindGameObjectsWithTag("door");
                    foreach (GameObject obj in doorobjs)
                    {
                        obj.GetComponent<Door>().Unlock();
                    }
                    audio[0].Play();
                    seconds = 90;
                    audio[1].Play((ulong)audio[0].time);
                }
            }
        }
        else if (seconds > 0)
        {
            player_can_take = false;
            seconds -= 1f / fps;
        }
        else
        {
            audio[2].Play();
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("scp");
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].GetComponent<Scp>().hp = 0;
            }
            if (player.transform.position.x < 30.7) player.GetComponent<Player>().hp = 0;
            seconds = -100f;
        }
    }

    private void OnGUI()
    {
        if (player_can_take)
        {
            GUI.DrawTexture(new Rect(400, 400, 60, 60), GameObject.Find("player").GetComponent<Main>().handsymbol);
        }
        if (seconds > 0)
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.LowerLeft;
            style.fontSize = 45;
            style.margin = new RectOffset(20, 20, 20, 20);
            GUILayout.Label(seconds.ToString() + " seconds before the explosion", style);
        }
    }
}
