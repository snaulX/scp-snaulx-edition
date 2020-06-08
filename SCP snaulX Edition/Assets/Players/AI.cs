using UnityEngine;
using System.Collections;
using System;

public class AI : MonoBehaviour
{
    public static Node[] nodegraph;
    Scp scp;
    Vector3 pos;
    Vector3 posi
    {
        get => transform.position;
    }
    bool stay = false;
    
    void Start()
    {
        scp = GetComponent<Scp>();
        pos = new Vector3();
    }

    void Update()
    {
        if (stay) stay = false;
        else
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
            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 7f, transform.position.z), transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 1.7f, out hit))
            {
                GameObject target = hit.transform.gameObject;
                Debug.Log(target.name + ' ' + name);
                if (hit.distance < 3.0f && hit.distance > -1f)
                {
                    if (target.CompareTag("glass"))
                    {
                        transform.LookAt(target.transform);
                        transform.Translate(3f, 0f, 0f);
                    }
                    else if (target.CompareTag("Player"))
                    {
                        scp.Kill();
                    }
                    else
                    {
                        transform.Rotate(0, UnityEngine.Random.Range(-110, 110), 0);
                    }
                    try
                    {
                        Door door = target.GetComponent<Door>();
                        if (!door.Lock && door.level < SecurityLevel.MTF)
                        {
                            door.Open();
                        }
                        else
                        {
                            transform.Rotate(0, UnityEngine.Random.Range(-120, 120), 0);
                        }
                    }
                    catch (NullReferenceException) { }
                }
            }
        }
    }

    public void Stop() => stay = true;
}
