using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scp1162 : MonoBehaviour
{
    float loose_hp = -1;
    private bool player_can_take = false;
    GameObject player
    {
        get => GameObject.Find("player");
    }

    void Update()
    {
        if (-3 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 3
            && -3 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 3)
        {
            player_can_take = true;
            if (Input.GetMouseButtonDown(0))
            {
                Player pl = player.GetComponent<Player>();
                if (pl.hp > 0)
                {
                    GetComponent<AudioSource>().Play();
                    pl.hp -= 60;
                    loose_hp = 180;
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
        /*if (player_can_take && player.GetComponent<Player>().hp > 0)
        {
            GUI.DrawTexture(new Rect(600, 600, 60, 60), player.GetComponent<Main>().handsymbol2);
        }*/
        if (loose_hp > 0)
        {
            GUI.Label(new Rect(100, 300, 100, 50), $"You have {GameObject.Find("player").GetComponent<Player>().hp} hp");
            loose_hp -= Time.deltaTime * 80;
        }
    }
}
