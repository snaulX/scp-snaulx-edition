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
    LevelDifficulty lvl;
    // Use this for initialization
    void Start()
    {
        blinking = 300;
        characterController = GetComponent<CharacterController>();
        lvl = (LevelDifficulty) PlayerPrefs.GetInt("level_difficulty");
        Scp scp173 = GameObject.Find("scp173").GetComponent<Scp>(), scp096 = GameObject.Find("scp096").GetComponent<Scp>();
        if (lvl == LevelDifficulty.Safe)
        {
            hp = 300;
            speed = 16f;
            scp173.hp = 2000;
            scp173.kill_points = 2000;
            scp173.speed = 14f;
            scp096.speed = 10f;
            scp096.kill_points = 300;
            scp096.hp = 1200;
        }
        else if (lvl == LevelDifficulty.Euclid)
        {
            hp = 200;
            speed = 14f;
            scp173.hp = 3000;
            scp173.kill_points = 3000;
            scp173.speed = 16f;
            scp096.speed = 11f;
            scp096.kill_points = 450;
            scp096.hp = 1400;
        }
        else
        {
            hp = 100;
            speed = 12f;
            scp173.hp = 4000;
            scp173.kill_points = 4000;
            scp173.speed = 18f;
            scp096.speed = 12f;
            scp096.kill_points = 600;
            scp096.hp = 1600;
        }
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
            if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene("SampleScene");
            else if (Input.GetKey(KeyCode.X))  Application.Quit();
        }
        else
        {
            if (end)
            {
                if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene("SampleScene");
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
        if (transform.position.x > 31.3)
        {
            GUILayout.Label("YOU WIN!!!", style);
            GUILayout.Label("Press R for restart or X for exit from the game", st);
            end = true;
        }
    }
}
