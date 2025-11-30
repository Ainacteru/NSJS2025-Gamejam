using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text health;
    public TMP_Text rooms;

    void Update()
    {
        health.text = PlayerShoot.playerHealth.ToString();
        rooms.text = GameManager.roomsBeaten.ToString();
    }
}