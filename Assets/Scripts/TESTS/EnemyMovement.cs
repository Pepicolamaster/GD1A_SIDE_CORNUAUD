using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    //creation des références dont on a besoin
    public GameObject pointA;
    public GameObject pointB;
    public Rigidbody2D rb;
    public Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //assignation des références
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform; //position du pointB pour qu'il y ai une position initiale
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position; //donne la direction dans laquelle l'ennemi veut aller
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform) //si l'ennemi a atteint le point asctuel et que le point actuel est pointB
        {
            Flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform) //si l'ennemi a atteint le point asctuel et que le point actuel est pointB
        {
            Flip();
            currentPoint = pointB.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<health>().TakeDamage();
        }
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
