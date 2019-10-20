using UnityEngine;
using System.Collections;

public class Keycard : MonoBehaviour
{
    [SerializeField]
    public SecurityLevel security;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");
        if (-4 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 4
            && -4 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 4
            && Input.GetKeyDown(KeyCode.E))
        {
            Player pl = player.GetComponent<Player>();
            if (pl.level < security)
            {
                pl.level = security;
                Destroy(gameObject);
            }
        }
    }
}
