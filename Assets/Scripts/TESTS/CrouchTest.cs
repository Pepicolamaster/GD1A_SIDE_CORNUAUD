using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchTest : MonoBehaviour
{
    private Vector2 normalHeight; //stocker hauteur de départ du personnage

    // Start is called before the first frame update
    void Start()
    {
        normalHeight = transform.localScale; //attribue la taille du joueur à normalHeight
    }
}
