using UnityEngine;

public class specialDoor : MonoBehaviour
{
    private Collider2D coll;
    public PlayerCam playerCam;

    private bool bossStarted = false;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Start boss once when condition is met
        if (!bossStarted && GameManager.roomsBeaten >= 10)
        {
            StartBoss();
        }
    }

    private void StartBoss()
    {
        // Prevent repeating the sequence
        if (bossStarted) return;
        bossStarted = true;

        coll.isTrigger = true;
        playerCam.maxZoom = 50;
        PlayerShoot.playerHealth = 200;

        Debug.Log("Boss Start triggered!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bossStarted) 
            StartBoss();
    }
}
