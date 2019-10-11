using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    Transform Transform
    {
        get => GameObject.Find("Main Camera").transform;
    }
    Vector3 pos
    {
        get => transform.position;
    }
    public float sensivity, vert, _rotationX;
    // Use this for initialization
    void Start()
    {
        sensivity = 6f;
        vert = 45f;
        _rotationX = 0f;
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * sensivity;
        _rotationX = Mathf.Clamp(_rotationX, -vert, vert);
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensivity, 0);
        Transform.localEulerAngles = new Vector3(_rotationX, Transform.localEulerAngles.y + (Input.GetAxis("Mouse X") * sensivity), 0f);
    }
}
