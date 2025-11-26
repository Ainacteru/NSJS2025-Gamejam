using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Walking")]
    [SerializeField] private float playerAccel = 10f;
    [SerializeField] private float maxSpeed = 8f;   
    [Space]
    [Header("Dash")]
    [SerializeField] private float dashSpeed = 5f;
    [SerializeField] private float dashCooldown = 1f;

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
        
        if (Input.GetKeyDown(KeyCode.Mouse0)) // change later prob
        {
            Dash();
        }

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

    public void Dash()
    {
        rb.AddForce(transform.up * dashSpeed, ForceMode2D.Impulse);
    }
}