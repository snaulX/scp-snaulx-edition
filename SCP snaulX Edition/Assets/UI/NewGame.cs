using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => OnClick());
    }

    // Update is called once per frame
    void Update()
    {
        //pass
    }

    public void OnClick()
    {
        PlayerPrefs.SetInt("level_difficulty", GameObject.Find("Dropdown").GetComponent<Dropdown>().value);
        SceneManager.LoadScene("SampleScene");
    }
}
