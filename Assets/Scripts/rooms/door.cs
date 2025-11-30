using UnityEngine;

public class door : MonoBehaviour
{
    public Collider2D coll;

    [HideInInspector] public Collider2D collision = null;
    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void Start()
    {
        Open();
    }

    public void Close()
    {
        coll.isTrigger = false;
    }

    public void Open()
    {
        coll.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        collision = other;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        collision = null;
    }
}