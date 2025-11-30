using UnityEngine;

public class start : MonoBehaviour
{
    [SerializeField] private box room;
    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        room.startRoom();
        gameObject.SetActive(false);
    }
}