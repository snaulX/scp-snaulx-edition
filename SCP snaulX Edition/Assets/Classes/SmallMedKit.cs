using UnityEngine;
using System.Collections;

public class SmallMedKit : MonoBehaviour
{
    private bool player_can_take;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                LevelDifficulty lvl = (LevelDifficulty)PlayerPrefs.GetInt("level_difficulty");
                Player pl = player.GetComponent<Player>();
                if ((lvl == LevelDifficulty.Safe && pl.hp <= 280) || (lvl == LevelDifficulty.Euclid && pl.hp <= 180) || (lvl == LevelDifficulty.Keter && pl.hp < 80))
                {
                    pl.hp += 20;
                    Destroy(gameObject);
                }
                else if (lvl == LevelDifficulty.Safe && pl.hp < 300)
                {
                    pl.hp = 300;
                    Destroy(gameObject);
                }
                else if (lvl == LevelDifficulty.Euclid && pl.hp < 200)
                {
                    pl.hp = 200;
                    Destroy(gameObject);
                }
                else if (lvl == LevelDifficulty.Keter && pl.hp < 100)
                {
                    pl.hp = 100;
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            player_can_take = false;
        }
    }

    /*private void OnGUI()
    {
        if (player_can_take)
        {
            GUI.DrawTexture(new Rect(600, 600, 60, 60), player.GetComponent<Main>().handsymbol2);
        }
    }*/
}
