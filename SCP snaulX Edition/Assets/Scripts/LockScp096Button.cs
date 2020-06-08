using UnityEngine;
using System.Collections;
using System;

public class LockScp096Button : MonoBehaviour
{
    private bool player_can_take = false;
    [SerializeField]
    float z_minus, z_plus, x_minus, x_plus;
    Door door;

    // Use this for initialization
    void Start()
    {
        door = GameObject.Find("door096").GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player.transform.position.z - transform.position.z < z_plus && z_minus < player.transform.position.z - transform.position.z
                && x_minus < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < x_plus)
            {
                player_can_take = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<AudioSource>().Play();
                    if (door.Lock) door.Unlock();
                    else door.Lockdown();
                }
            }
            else
            {
                player_can_take = false;
            }
        }
        catch (NullReferenceException)
        {
            //ничего не делать
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
