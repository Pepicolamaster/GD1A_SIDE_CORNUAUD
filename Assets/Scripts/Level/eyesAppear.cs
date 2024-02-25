using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesAppear : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
        }
    }
}
