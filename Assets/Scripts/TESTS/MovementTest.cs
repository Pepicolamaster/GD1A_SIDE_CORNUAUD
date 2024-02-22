using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovementTest : MonoBehaviour
{
    //variables pour l'input horizontal, la vitesse, puissance de saut et un booléen pour savoir si le joueur regarde à droite
    private float horizontal;
    public float speed;
    public float walkingSpeed;
    public float crouchSpeed;
    public float jumpingPower;
    public bool isFacingRight = true;
    public bool isStanding = true;
    public Animator animator;

    //pour le crouch
    //public SpriteRenderer SpriteRenderer;
    //public Sprite Standing;
    //public Sprite Crouching;
    public BoxCollider2D Collider;
    public Vector2 StandingSize;
    public Vector2 StandingOffset;
    public Vector2 CrouchingSize;
    public Vector2 CrouchingOffset;
    public bool isCrouching = false;

    //pour le double saut
    public int jumpCount = 0;

    //références au rigidbody du joueur, la position du groundCheck et la layer du sol
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool isDead = false;


    private void Start()
    {
        StandingSize = Collider.size;
    }


    // Update is called once per frame
    void Update()
    {
        //MOUVEMENT DROITE GAUCHE
        //renvoie 1 0 ou -1 selon la direction
        horizontal = Input.GetAxisRaw("Horizontal");

        float characterVelocity = Mathf.Abs(rb.velocity.x); //dans une variable, on convertit la valeur négative en valeur positive (mouvement vers la gauche = -1) l'animator ne comprend pas un chiffre négatif pour Speed
        animator.SetFloat("speed", characterVelocity); //on se réfère à l'animator pouir lui envoyer la vitesse du joueur






        //SAUT
        if (IsGrounded())
        {
            jumpCount = 0;
        }
        if (jumpCount < 1)
        {
            if (Input.GetButtonDown("Jump") && IsGrounded() && !isCrouching && !isDead)
            {
                //on assigne au Y du rigidbody le jumpingPower définit
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                jumpCount += 1;
            }
            if (Input.GetButtonDown("Jump") && !isCrouching &&!isDead)
            {
                //on assigne au Y du rigidbody le jumpingPower définit
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                jumpCount += 1;
            }

            //si le joueur bouge toujours vers le haut mais la touche saut est lâchée, on multiplie Y par 0.5
            //permet de sauter plus haut en maintenant la touche saut
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

















        //CROUCH
        if (Input.GetKeyDown(KeyCode.DownArrow) && rb.velocity.y == 0) //s'accroupir
        {
            Collider.size = CrouchingSize;
            Collider.offset = CrouchingOffset;
            speed = crouchSpeed;
            isCrouching = true;
            animator.SetBool("isCrouching", true);
            float characterVelocityCrouched = Mathf.Abs(rb.velocity.x); //dans une variable, on convertit la valeur négative en valeur positive (mouvement vers la gauche = -1) l'animator ne comprend pas un chiffre négatif pour Speed
            animator.SetFloat("speed", characterVelocityCrouched);
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                isCrouching = false;
                animator.SetBool("isCrouching", false);
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow)) //se relever
        {
            Collider.size = StandingSize;
            Collider.offset = StandingOffset;
            speed = walkingSpeed;
            isStanding = true;
            animator.SetBool("isCrouching", false);
            isCrouching = false;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        //on change la vélocité du Rigidbody par l'input horizontal * la vitesse
        if (!isDead)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded() //pour le saut du joueur
    {
        //on définit un cercle : son centre est la position du groundCheck, son rayon est de 0.2 et il check le layer du sol
        //créé un cercle invisible qui permet de sauter s'il touche le sol
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        //SI le joueur regarde vers la droite ET l'input horizontal est inférieur à 0
        //OU le joueur ne regarde pas vers la droite ET l'input horizontal est supérieur à 0
        //on FLIP le joueur
        if ((isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) && !isDead)
        {
            //isFacingRight devient son opposé (TRUE ou FALSE)
            //on multiplie le scale X du joueur par -1
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Die()
    {
        isDead = true;
    }
}