using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    public health currentHealth;
    public Animator anim;
    public GameObject img;

    // Start is called before the first frame update
    void Start()
    {
        LifeBar();
    }

    // Update is called once per frame
    void Update()
    {
        LifeBar();
    }
    void LifeBar()
    {
        if (currentHealth.GetCurrentHealth() >= 3)
        {
            anim.Play("3hp");
        }
        if (currentHealth.GetCurrentHealth() == 2)
        {
            anim.Play("2hp");
        }
        if (currentHealth.GetCurrentHealth() == 1)
        {
            anim.Play("1hp");
        }
        if (currentHealth.GetCurrentHealth() <= 0)
        {
            img.GetComponent<Image>().enabled = false;
        }
    }
}
