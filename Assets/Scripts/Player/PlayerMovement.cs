using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float playerAccel = 10f;
    public float maxSpeed = 8f;   

    Vector2 input = new Vector2();
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        HandleInput(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));

        Move();

    }

    private void Move()
    {
        rb.AddForce(input * playerAccel);

        if (rb.linearVelocity.magnitude > maxSpeed) {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    private void HandleInput(float vertAxis, float horzAxis)
    {
        input.x = horzAxis;
        input.y = vertAxis;

        input = input.normalized;
    }
}