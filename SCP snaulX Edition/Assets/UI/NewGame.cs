using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => OnClick());
    }

    public void OnClick()
    {
        PlayerPrefs.SetInt("level_difficulty", GameObject.Find("Dropdown").GetComponent<Dropdown>().value);
        SceneManager.LoadScene("SampleScene");
    }
}
