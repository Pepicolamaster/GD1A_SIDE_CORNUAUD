using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elimination : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator anim;
    public GameObject enemyHB;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyHB.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(objectToDestroy, 0.5f);
            anim.SetBool("isAlive", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
