using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(SpriteRenderer),typeof(Collider2D))]
public class playerController : MonoBehaviour
{
    [SerializeField] private float groundCheckRadius = 0.02f;

    [SerializeField] private bool isGrounded = false;
    private LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D col;

    private Vector2 groundCheckPos;
    Vector2 GetGroundCheckPos()
    {
        return new Vector2(col.bounds.min.x + col.bounds.extents.x, col.bounds.min.y);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();


        groundLayer = LayerMask.GetMask("Ground");

        if (groundLayer == 0)
            Debug.LogWarning("Ground layer not set");

    }

    // Update is called once per frame
    void Update()
    {
        float hValue = Input.GetAxis("Horizontal");
        spriteFlip(hValue);
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, groundCheckRadius, groundLayer);

        groundCheckPos = GetGroundCheckPos();

        rb.linearVelocityX = hValue * 5f;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }

    void spriteFlip(float hValue)
    {
        if (hValue != 0)
        {
            sr.flipX = (hValue < 0);
        }
    }
}
