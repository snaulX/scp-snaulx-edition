using UnityEngine;

public class Scp: MonoBehaviour
{
    public float speed;
    public short damage, hp;
    public AudioSource death_audio;
    public static GameObject enemy;
    Vector3 position
    {
        get => transform.position;
    }

    public Scp(): base()
    {
        hp = 0;
        damage = 0;
        speed = 0f;
    }

    public Scp(short kill_points, float speed, short hp)
    {
        damage = kill_points;
        this.speed = speed;
        this.hp = hp;
    }

    public void Start()
    {
        enemy = GameObject.FindWithTag("Player");
    }

    public void Kill()
    {
        Ray ray = new Ray(new Vector3(position.x, position.y + 7f, position.z), transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 3.5f, out hit) && hit.distance < 1f)
        {
            Player pl = hit.transform.gameObject.GetComponent<Player>();
            if (pl != null && pl.hp > 0)
            {
                try
                {
                    death_audio.Play();
                }
                catch { }
                pl.hp = (short)(pl.hp - damage);
            }
        }
    }

    private void Update()
    {
        if (hp <= 0)
            Destroy(gameObject);
    }
}
