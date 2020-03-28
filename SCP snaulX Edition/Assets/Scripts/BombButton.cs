using UnityEngine;
using UnityEngine.SceneManagement;

public class BombButton : MonoBehaviour
{
    public float seconds;
    private bool player_can_take = false;

    public float fps
    {
        get => GameObject.Find("Main").GetComponent<Main>().fps;
    }
    // Use this for initialization
    void Start()
    {
        seconds = -100f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");
        AudioSource[] audio = GetComponents<AudioSource>();
        if (seconds == -100f)
        {
            if (-2 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 2
                && -2 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 2)
            {
                player_can_take = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    foreach (GameObject obj in GameObject.FindGameObjectsWithTag("door"))
                    {
                        obj.GetComponent<Door>().Unlock();
                    }
                    audio[0].Play();
                    seconds = 90;
                    audio[1].Play((ulong)audio[0].time);
                }
            }
        }
        else if (seconds > 0)
        {
            player_can_take = false;
            seconds -= 1f / fps;
        }
        else
        {
            //booom
            audio[2].Play();
            foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                if (Helper.InFacility(obj))
                {
                    if (obj.CompareTag("Player")) obj.GetComponent<Player>().Die();
                    else Destroy(obj);
                }
            } //destroy facility
            GameObject.Find("door").GetComponent<Door>().Lockdown(); //lock exit
            seconds = -100f;
        }
    }

    private void OnGUI()
    {
        if (player_can_take)
        {
            GUI.DrawTexture(new Rect(400, 400, 60, 60), GameObject.Find("player").GetComponent<Main>().handsymbol);
        }
        if (seconds > 0)
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.LowerLeft;
            style.fontSize = 45;
            style.margin = new RectOffset(20, 20, 20, 20);
            GUILayout.Label(seconds.ToString() + " seconds before the explosion", style);
        }
    }
}
