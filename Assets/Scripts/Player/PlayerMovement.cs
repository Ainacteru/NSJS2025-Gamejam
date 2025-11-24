using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float playerSpeed;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
    }

    private void Move(float vertAxis, float horzAxis)
    {
        Vector2 force = new Vector2(horzAxis, vertAxis) * playerSpeed; 
        rb.AddForce(force);
    }
}