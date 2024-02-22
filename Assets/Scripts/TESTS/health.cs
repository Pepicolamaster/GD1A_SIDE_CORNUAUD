using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 3;
    public Rigidbody2D rb;
    public MovementTest movement;
    public Image sprite;

    //sprite barre de vie

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //la vie actuelle est égale à la vie max au lancement du jeu
    }

    public void TakeDamage()
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            //mort, check pour ne pas voir une vie négative
            //animation de mort
            anim.SetBool("isDead", true);
            rb.freezeRotation = false;
            movement.Die();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}