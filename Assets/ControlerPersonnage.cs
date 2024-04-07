using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerPersonnage : MonoBehaviour
{
    public float vitesseX; //vitesse horizontale actualle
    public float vitesseXMax; //vitesse horizontale d�sir�e
    public float vitesseY; //vitesse verticale 
    public float vitesseSaut; //vitesse de saut d�sir�e



    //D�tection des touches du clavier et modification des vitesses en cons�quence
    // "a" et "d" pour d�placement horizontale et "w" pour sauter

    // Update is called once per frame
    void Update()
    {
        // d�placement vers la gauche
        if (Input.GetKey("a"))
        {
            vitesseX = -vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = true; //retourne le sprite
        }
        else if (Input.GetKey("d")) // d�placement vers la droite
        {
            vitesseX = vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = false; //retourne le sprite
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x; //m�morise vitesse actualle en X
        }

        // sauter l'objet � l'aide de la touche "w"
        if (Input.GetKeyDown("w"))
        {
            vitesseY = vitesseSaut;
            GetComponent<Animator>().SetBool("saute", true);
        }
        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y; //m�morise vitesse actualle en Y
        }

        //Applique les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

        //Gestions des animations de course et repos
        //Active l'animation de course si la vitesse en X est diff�rente de 0, sinon le repos sera jouer par Animator

        if (vitesseX > 0.1 || vitesseX < -0.1)
        {
            GetComponent<Animator>().SetBool("course", true);
        } else
        {
            GetComponent<Animator>().SetBool("course", false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //D�sactive l'animation de saut si l'objet touche le sol
        if (collision.gameObject.tag == "sol")
        {
            GetComponent<Animator>().SetBool("saute", false);
        }
    }
}