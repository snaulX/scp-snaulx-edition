using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    const float ARM_LENGTH = 7.7f;
    public float speed;
    public short hp;
    public bool end = false, die = false, can_take = false, can_open = false;
    Vector3 pos
    {
        get => transform.position;
    }
    new AudioSource audio;
    public AudioSource pickItem_audio, toBeContinued;
    CharacterController characterController;
    public SecurityLevel level;
    LevelDifficulty lvl;
    public GameObject spawn;
    Transform spawn_info;
    Texture take, open;
    Camera camera;
    GUIStyle style = new GUIStyle(), st;
    KeyCode restart, exitGame, piсkItem, operateDoor;
    string endMessage;
    
    void Start()
    {
        restart = Helper.keyCodes[PlayerPrefs.GetInt("restart")];
        exitGame = Helper.keyCodes[PlayerPrefs.GetInt("exitGame")];
        piсkItem = Helper.keyCodes[PlayerPrefs.GetInt("pickItem")];
        operateDoor = Helper.keyCodes[PlayerPrefs.GetInt("operateDoor")];
        Debug.Log(operateDoor);
        endMessage = $"Press {restart.ToString()} for restart or {exitGame.ToString()} for exit from the game";
        camera = GetComponentInChildren<Camera>();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 220;
        st = new GUIStyle(style);
        st.fontSize = 75;
        Main main = GameObject.Find("Main").GetComponent<Main>();
        take = main.handsymbol2;
        open = main.handsymbol;
        toBeContinued = gameObject.AddComponent<AudioSource>();
        toBeContinued.clip = main.toBeContinued;
        spawn_info = spawn.transform;
        audio = GetComponent<AudioSource>();
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        lvl = (LevelDifficulty) PlayerPrefs.GetInt("level_difficulty");
        Scp scp173 = GameObject.Find("scp173").GetComponent<Scp>(), scp096 = GameObject.Find("scp096").GetComponent<Scp>(),
            scp049 = GameObject.Find("scp049").GetComponent<Scp>();
        if (lvl == LevelDifficulty.Safe)
        {
            hp = 300;
            speed = 16f;
            scp173.hp = 2000;
            scp173.damage = 2000;
            scp173.speed = 14.5f;
            scp096.speed = 10f;
            scp096.damage = 300;
            scp096.hp = 1200;
            scp049.speed = 9.2f;
            scp049.damage = 200;
            scp049.hp = 1000;
        }
        else if (lvl == LevelDifficulty.Euclid)
        {
            hp = 200;
            speed = 14f;
            scp173.hp = 3000;
            scp173.damage = 3000;
            scp173.speed = 16f;
            scp096.speed = 11f;
            scp096.damage = 450;
            scp096.hp = 1400;
            scp049.speed = 10.5f;
            scp049.damage = 320;
            scp049.hp = 1100;
        }
        else
        {
            hp = 100;
            speed = 12f;
            scp173.hp = 4000;
            scp173.damage = 4000;
            scp173.speed = 18f;
            scp096.speed = 12f;
            scp096.damage = 600;
            scp096.hp = 1600;
            scp049.speed = 12.5f;
            scp049.damage = 440;
            scp049.hp = 1250;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
        if (hp <= 0)
        {
            if (!die) Die();
            if (Input.GetKey(restart)) SceneManager.LoadScene("SampleScene");
            else if (Input.GetKey(exitGame)) Application.Quit();
        }
        else
        {
            if (pos.x < 59.5)
            {
                toBeContinued.Play();
            }
            if (end)
            {
                if (Input.GetKey(restart)) SceneManager.LoadScene("SampleScene");
                else if (Input.GetKey(exitGame)) Application.Quit();
            }
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, ARM_LENGTH)) //on short distance
            {
                GameObject target = hit.transform.gameObject;
                string tname = target.name;
                Debug.Log($"RAY {target.name} on short distance");
                Keycard card = target.GetComponent<Keycard>();
                if (card != null)
                {
                    can_take = true;
                    if (Input.GetKeyDown(piсkItem))
                    {
                        try { pickItem_audio.Play(); }
                        catch (Exception e) { Debug.Log(e); }
                        if (level < card.security)
                        {
                            level = card.security;
                            Destroy(card.gameObject);
                        }
                    }
                }
                else if (tname == "Tank_cover.001" && Input.GetKeyDown(piсkItem))
                {
                    target.GetComponentInParent<AudioSource>().Play();
                }
                else if (tname.StartsWith("door") || tname == "LeftDoor" ||
                    tname == "RightDoor" || tname.StartsWith("toilet-door"))
                {
                    if (Input.GetKeyDown(operateDoor))
                    {
                        Door door = target.GetComponent<Door>() ?? target.GetComponentInChildren<Door>();
                        if (level >= door.level) door.Open();
                        else door.audio.Play();
                    }
                }
                else
                {
                    can_take = false;
                    can_open = false;
                }
            }
            else if (Physics.Raycast(ray, out hit)) //on other distance
            {
                GameObject target = hit.transform.gameObject;
                Debug.Log("RAY " + target.name);
                if (target.name == "scp173")
                {
                    target.GetComponent<AI>().Stop();
                }
            }
            float x = Input.GetAxis("Vertical"), z = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(z * speed * Time.deltaTime, 0f, x * speed * Time.deltaTime);
            transform.Translate(movement);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement = transform.TransformDirection(movement);
            characterController.Move(movement);
        }
    }

    private void OnGUI()
    {
        if (can_take)
        {
            GUI.DrawTexture(new Rect(100, 100, 100, 100), take);
        }
        if (hp <= 0)
        {
            GUILayout.Label(endMessage, st);
            end = true;
        }
        if (!Helper.InFacility(gameObject))
        {             
            GUILayout.Label("YOU WIN!!!", style);
            GUILayout.Label(endMessage, st);
            end = true;
        }
    }

    public void Die()
    {
        hp = 0;
        die = true;
        transform.Rotate(83, 0, 0);
    }
}
