using UnityEngine;
using System.Collections;

public class Scp096 : MonoBehaviour
{
    Scp scp
    {
        get => GetComponent<Scp>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scp.hp <= 0)
            Destroy(gameObject);
        scp.Kill();
    }

    private void OnDestroy()
    {
        Debug.Log("scp 096 is die");
    }
}
