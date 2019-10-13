using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    public int blinking;
    public float speed;
    public short hp;
    public bool end = false;
    Vector3 pos
    {
        get => transform.position;
    }
    CharacterController characterController;
    public SecurityLevel level;
    // Use this for initialization
    void Start()
    {
        blinking = 300;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel")) SceneManager.LoadScene(0);
        blinking--;
        if (blinking < -10)
        {
            blinking = 300;
        }
        else if (blinking < 0)
        {
            //screen will be black on second
        }
        if (hp <= 0)
        {
            //Destroy(gameObject);
            if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene(1);
            else if (Input.GetKey(KeyCode.X))  Application.Quit();
        }
        else
        {
            if (end)
            {
                if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene(1);
                else if (Input.GetKey(KeyCode.X)) Application.Quit();
            }
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * speed * Time.deltaTime);
            transform.Translate(movement);
            Transform t = GameObject.Find("Main Camera").transform;
            t.position = new Vector3(pos.x, pos.y + 5.62f, pos.z);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement = transform.TransformDirection(movement);
            characterController.Move(movement);
        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 220;
        GUIStyle st = new GUIStyle(style);
        st.fontSize = 75;
        if (hp <= 0)
        {
            GUILayout.Label("\n Press R for restart or X for exit from the game", st);
            end = true;
        }
        if (transform.position.x > 31)
        {
            GUILayout.Label("YOU WIN!!!", style);
            GUILayout.Label("Press R for restart or X for exit from the game", st);
            end = true;
        }
    }
}
