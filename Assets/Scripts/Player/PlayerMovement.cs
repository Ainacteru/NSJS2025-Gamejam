using Unity.VisualScripting;
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
    [SerializeField] private float dashCooldown = 0.5f;
    private float dashtime = 0;

    private Collision2D colliding;
    Vector2 input = new Vector2();
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (dashtime > 0)
            dashtime -= Time.deltaTime;

        if (dashtime <= 0 && Input.GetKeyDown(KeyCode.R))
        {
            Dash();
            dashtime = dashCooldown;
        }
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

    private void Dash()
    {
        rb.AddForce(transform.up * dashSpeed, ForceMode2D.Impulse);
    }


        
 

    void OnCollisionEnter2D(Collision2D col) {
        colliding = col;
    }

    void OnCollisionExit2D(Collision2D col) {
        colliding = null;
    }
}