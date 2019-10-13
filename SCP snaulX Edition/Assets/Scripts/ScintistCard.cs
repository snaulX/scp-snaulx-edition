using UnityEngine;
using System.Collections;

public class ScintistCard : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (-3 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 3
            && -3 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 3
            && Input.GetKeyDown(KeyCode.E))
        {
            Player pl = player.GetComponent<Player>();
            if (pl.level < SecurityLevel.Scientist)
            {
                pl.level = SecurityLevel.Scientist;
                Destroy(gameObject);
            }
        }
    }
}
