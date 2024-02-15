using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TEST : MonoBehaviour
{
    //variables pour l'input horizontal, la vitesse, puissance de saut et un booléen pour savoir si le joueur regarde à droite
    private float horizontal;
    public float speed;
    public float jumpingPower;
    public bool isFacingRight = true;

    //références au rigidbody du joueur, la position du groundCheck et la layer du sol
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        //renvoie 1 0 ou -1 selon la direction
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //on assigne au Y du rigidbody le jumpingPower définit
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        //si le joueur bouge toujours vers le haut mais la touche saut est lâchée, on multiplie Y par 0.5
        //permet de sauter plus haut en maintenant la touche saut
        if (Input.GetButtonUp("Jump") && rb.velocity.y >0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        //on change la vélocité du Rigidbody par l'input horizontal * la vitesse
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() //pour le saut du joueur
    {
        //on définit un cercle : son centre est la position du groundCheck, son rayon est de 0.2 etil check le layer du sol
        //créé un cercle invisible qui permet de sauter s'il touche le sol
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        //SI le joueur regarde vers la droite ET l'input horizontal est inférieur à 0
        //OU le joueur ne regarde pas vers la droite ET l'input horizontal est supérieur à 0
        //on FLIP le joueur
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            //isFacingRight devient son opposé (TRUE ou FALSE)
            //on multiplie le scale X du joueur par -1
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
