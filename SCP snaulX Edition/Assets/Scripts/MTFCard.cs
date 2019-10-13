using UnityEngine;
using System.Collections;

public class MTFCard : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");
        if (-3 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 3
            && -3 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 3
            && Input.GetKeyDown(KeyCode.E))
        {
            Player pl = player.GetComponent<Player>();
            if (pl.level < SecurityLevel.MTF)
            {
                pl.level = SecurityLevel.MTF;
                Destroy(gameObject);
            }
        }
    }
}
