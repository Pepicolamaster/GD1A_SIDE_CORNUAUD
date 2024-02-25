using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpJump : MonoBehaviour
{
    public MovementTest doubleJump;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovementTest>().UnlockDoubleJump();
            Destroy(this.gameObject);
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
