using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scp1162 : MonoBehaviour
{
    float loose_hp = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");
        if (-3 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 3
            && -3 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 3
            && Input.GetMouseButtonDown(0))
        {
            Player pl = player.GetComponent<Player>();
            GetComponent<AudioSource>().Play();
            pl.hp -= 60;
            loose_hp = 180;
        }
    }

    private void OnGUI()
    {
        if (loose_hp > 0)
        {
            GUI.Label(new Rect(100, 300, 100, 50), $"You have {GameObject.Find("player").GetComponent<Player>().hp} hp");
            loose_hp = loose_hp - Time.deltaTime * 80;
        }
    }
}
