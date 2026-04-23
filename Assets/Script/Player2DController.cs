using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 450;

    private bool isGrounded;

    private Rigidbody2D rb;
    private float moveInputValue;

    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null)
        {
            moveInputValue = Keyboard.current.dKey.isPressed ? 1 : 0
            -(Keyboard.current.aKey.isPressed ? 1 : 0);
        }

        rb.linearVelocity = new Vector2(moveInputValue * speed, rb.linearVelocity.y);

        if (moveInputValue < 0) { spriteRenderer.flipX = true; }
        else if (moveInputValue > 0) { spriteRenderer.flipX = false; }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
