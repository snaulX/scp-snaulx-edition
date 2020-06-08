using UnityEngine;
using System.Collections;
using System;

public class LockScp173Button : MonoBehaviour
{
    private bool player_can_take = false;

    void Update()
    {
        GameObject player = GameObject.Find("player");
        if (-3 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 3
            && -3 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 3)
        {
            player_can_take = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Door[] doors = GameObject.Find("big-door").GetComponentsInChildren<Door>();
                try
                {
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.PlayOneShot(audio.clip);
                }
                catch { }
                foreach (Door door in doors)
                {
                    if (door.Lock) door.Unlock();
                    else door.Lockdown();
                }
            }
        }
        else
        {
            player_can_take = false;
        }
    }

    private void OnGUI()
    {
        if (player_can_take)
        {
            GUI.DrawTexture(new Rect(400, 400, 60, 60), GameObject.Find("player").GetComponent<Main>().handsymbol);
        }
    }
}
