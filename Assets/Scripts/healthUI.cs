using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    public health currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        LifeBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LifeBar()
    {
        Sprite threeHP = Resources.Load<Sprite>("healthbar_prov_spritesheet_2");
        Sprite twoHP = Resources.Load<Sprite>("healthbar_prov_spritesheet_1");
        Sprite oneHP = Resources.Load<Sprite>("healthbar_prov_spritesheet_0");

        if (currentHealth.GetCurrentHealth() >= 3)
        {
            gameObject.GetComponent<Image>().sprite = threeHP;
        }

            if (currentHealth.GetCurrentHealth() == 2)
        {
            gameObject.GetComponent<Image>().sprite = twoHP;
        }

        if (currentHealth.GetCurrentHealth() == 1)
        {
            gameObject.GetComponent<Image>().sprite = oneHP;
        }
        if (currentHealth.GetCurrentHealth() <= 0)
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
