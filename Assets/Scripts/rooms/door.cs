using UnityEngine;

public class door : MonoBehaviour
{
    Collider2D coll;

    public Collider2D collision = null;
    void Awake()
    {
        coll = gameObject.GetComponent<Collider2D>();
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