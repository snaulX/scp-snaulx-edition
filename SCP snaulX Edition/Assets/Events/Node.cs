using UnityEngine;

/// <summary>
/// Script of navigation node for AI
/// </summary>
public class Node : MonoBehaviour
{
    [SerializeField]
    private float[] movement;

    public void RandomRotate(GameObject obj)
    {
        System.Random rnd = new System.Random();
        obj.transform.Rotate(0, movement[rnd.Next(movement.Length)], 0);
        obj.transform.Translate(0, 0.1f, 0);
    }
}
