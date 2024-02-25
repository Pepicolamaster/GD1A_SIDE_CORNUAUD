using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool wantsJumping;
    private bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    public BoxCollider2D crouchedHb;
    public BoxCollider2D standingHb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        
    }
    
    private void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            wantsJumping = true;
        }
    }
    

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (wantsJumping && isGrounded)
        {
            isJumping = true;
            wantsJumping = false;
        }
        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
        if (Input.GetKeyDown("DownArrow"))
        {
            if (!isJumping && isGrounded)
            {
                GetComponent<BoxCollider2D>().size = new Vector2(1f, 0.5f);
            }
        }

    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
