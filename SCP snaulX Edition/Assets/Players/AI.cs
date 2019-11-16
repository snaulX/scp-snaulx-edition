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
            scp.Kill();
            GameObject target = hit.transform.gameObject;
            if (hit.distance < 3.0f && hit.distance > -1f)
            {
                if (target.tag == "Wall")
                {
                    transform.Rotate(0, UnityEngine.Random.Range(-110, 110), 0);
                }
                if (target.tag == "glass")
                {
                    transform.LookAt(target.transform);
                    transform.Translate(3f, 0f, 0f);
                }
                try
                {
                    Door door = target.GetComponent<Door>();
                    if (!door.Lock)
                    {
                        door.Open();
                    }
                    else
                    {
                        transform.Rotate(0, UnityEngine.Random.Range(-90, 90), 0);
                    }
                }
                catch (NullReferenceException) { }
            }
        }
    }
}
