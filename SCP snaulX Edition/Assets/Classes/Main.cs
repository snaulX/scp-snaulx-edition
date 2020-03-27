using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public enum LevelDifficulty
{
    Safe,
    Euclid,
    Keter
}

public class Main : MonoBehaviour
{
    public Texture handsymbol, handsymbol2;
    public AudioClip pick_card;
    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    public float fps;

    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = 20;
        GUILayout.Label(" " + fps.ToString() + " FPS", style);
    }

    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }
    }
}

public static class Handler
{
    public static readonly List<KeyCode> keyCodes = Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().ToList();
    public static List<GameObject> disabled = new List<GameObject>();
}
