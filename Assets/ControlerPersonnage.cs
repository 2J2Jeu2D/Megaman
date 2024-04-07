using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerPersonnage : MonoBehaviour
{
    public float vitesseX; //vitesse horizontale actualle
    public float vitesseXMax; //vitesse horizontale désirée
    public float vitesseY; //vitesse verticale 
    public float vitesseSaut; //vitesse de saut désirée



    //Détection des touches du clavier et modification des vitesses en conséquence
    // "a" et "d" pour déplacement horizontale et "w" pour sauter

    // Update is called once per frame
    void Update()
    {
        // déplacement vers la gauche
        if (Input.GetKey("a"))
        {
            vitesseX = -vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = true; //retourne le sprite
        }
        else if (Input.GetKey("d")) // déplacement vers la droite
        {
            vitesseX = vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = false; //retourne le sprite
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x; //mémorise vitesse actualle en X
        }

        // sauter l'objet à l'aide de la touche "w"
        if (Input.GetKeyDown("w"))
        {
            vitesseY = vitesseSaut;
            GetComponent<Animator>().SetBool("saute", true);
        }
        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y; //mémorise vitesse actualle en Y
        }

        //Applique les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

        //Gestions des animations de course et repos
        //Active l'animation de course si la vitesse en X est différente de 0, sinon le repos sera jouer par Animator

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
        //Désactive l'animation de saut si l'objet touche le sol
        if (collision.gameObject.tag == "sol")
        {
            GetComponent<Animator>().SetBool("saute", false);
        }
    }
}