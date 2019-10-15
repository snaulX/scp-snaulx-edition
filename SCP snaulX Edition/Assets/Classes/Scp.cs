using UnityEngine;
using System.Collections;
using System;

public class Scp: MonoBehaviour
{
    public float speed;
    public short kill_points, hp;
    public GameObject enemy
    {
        get
        {
            try
            {
                return GameObject.FindWithTag("Player");
            }
            catch (NullReferenceException)
            {
                return GameObject.FindGameObjectWithTag("Player");
            }
        }
    }
    Vector3 position
    {
        get => transform.position;
    }

    public Scp(): base()
    {
        hp = 0;
        kill_points = 0;
        speed = 0f;
    }

    public Scp(short kill_points, float speed, short hp)
    {
        this.kill_points = kill_points;
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
                pl.hp = (short)(pl.hp - kill_points);
        }
    }
}
