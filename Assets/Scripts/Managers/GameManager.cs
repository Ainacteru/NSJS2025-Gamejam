using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float difficulty = 1f;
    public static float roomsBeaten = 0f;

    void Start()
    {
        difficulty = 1f;
        roomsBeaten = 0f;
    }
}