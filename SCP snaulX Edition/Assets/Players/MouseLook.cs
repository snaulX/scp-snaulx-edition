using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    Transform Transform
    {
        get => GameObject.Find("player").GetComponentInChildren<Camera>().transform;
    }
    Vector3 pos
    {
        get => transform.position;
    }
    public float _rotationX;
    // Use this for initialization
    void Start()
    {
        _rotationX = 0f;
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * 6f;
        _rotationX = Mathf.Clamp(_rotationX, -30f, 60f);
        transform.Rotate(0, Input.GetAxis("Mouse X") * 6f, 0);
        Transform.localEulerAngles = new Vector3(_rotationX - 0.1f, Transform.localEulerAngles.y);
    }
}
