using UnityEngine;

public class specialDoor : MonoBehaviour
{
    private Collider2D coll;
    public PlayerCam playerCam;
    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(GameManager.roomsBeaten >= 10)
        {
            StartBoss();
        }
    }

    private void StartBoss()
    {
        coll.isTrigger = true;
        playerCam.maxZoom = 50;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        StartBoss();
    }

}
