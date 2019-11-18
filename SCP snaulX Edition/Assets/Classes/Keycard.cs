using UnityEngine;
using System.Collections;
using System;

public class Keycard : MonoBehaviour
{
    [SerializeField]
    public SecurityLevel security;
    private bool player_can_take = false;
    private AudioSource take = new AudioSource();
    // Use this for initialization
    void Start()
    {
        take.clip = GameObject.Find("player").GetComponent<Main>().pick_card;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");
        if (-4 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 4
            && -4 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 4)
        {
            player_can_take = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player pl = player.GetComponent<Player>();
                try { take.Play(); }
                catch (Exception e) { Debug.Log(e); }
                if (pl.level < security)
                {
                    pl.level = security;
                    Destroy(gameObject);
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
            GUI.DrawTexture(new Rect(400, 400, 60, 60), GameObject.Find("player").GetComponent<Main>().handsymbol2);
        }
    }
}
