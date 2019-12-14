using UnityEngine;
using System.Collections;
using System;

public class Scp: MonoBehaviour
{
    public float speed;
    public short damage, hp;
    public AudioSource death_audio;
    public GameObject enemy
    {
        get => GameObject.FindWithTag("Player");
    }
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

    public void Kill()
    {
        if (-2 < enemy.transform.position.z - position.z && enemy.transform.position.z - position.z < 2
            && -2 < enemy.transform.position.x - position.x && enemy.transform.position.x - position.x < 2)
        {
            Player pl = enemy.GetComponent<Player>();
            if (pl.hp > 0)
            {
                try
                {
                    death_audio.Play();
                }
                catch (Exception)
                {
                    //просто нет музыки которая бы играла при смерти игрока, но смерть происходит
                }
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
