using UnityEngine;
using System.Collections;
using System;

public class AI : MonoBehaviour
{
    Scp scp
    {
        get => GetComponent<Scp>();
    }
    Vector3 pos;
    Vector3 posi
    {
        get => transform.position;
    }
    // Use this for initialization
    void Start()
    {
        pos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        if (pos == new Vector3())
            movement = new Vector3(0, 0, scp.speed * Time.deltaTime);
        else
            movement = new Vector3((posi.x - Math.Abs(pos.x)) * scp.speed * Time.deltaTime, 0, (posi.z - pos.z) * scp.speed * Time.deltaTime);
        transform.Translate(movement);
        movement = Vector3.ClampMagnitude(movement, scp.speed);
        movement = transform.TransformDirection(movement);
        GetComponent<CharacterController>().Move(movement);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject target = hit.transform.gameObject;
            if (hit.distance < 3.0f)
            {
                try
                {
                    target.GetComponent<Door>().Open();
                }
                catch (NullReferenceException)
                {
                    scp.Kill();
                }
                finally
                {
                    if (PlayerPrefs.GetInt("level_difficulty") == (int)LevelDifficulty.Keter && target.name == "player")
                        transform.forward = new Vector3(target.transform.position.x, 0, target.transform.position.z);
                    else
                        transform.Rotate(0, UnityEngine.Random.Range(-100, 100), 0);
                }
            }
        }
    }
}
