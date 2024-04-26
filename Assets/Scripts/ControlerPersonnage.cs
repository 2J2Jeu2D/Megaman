using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerPersonnage : MonoBehaviour
{
    public float vitesseX; //vitesse horizontale actualle
    public float vitesseXMax; //vitesse horizontale d�sir�e
    public float vitesseY; //vitesse verticale 
    public float vitesseSaut; //vitesse de saut d�sir�e

    public bool attaquePossible; //variable pour l'attaque

    // D�claration de la variable public de l�objet son
    public AudioClip sonMort;

    AudioSource sourceAudio; //Audio

    public bool partieTerminee; // variable pour la fin de la partie

    // Fonction qui s�ex�cute au d�but de la partie
    void Start()
    {
        sourceAudio = GetComponent<AudioSource>(); //Initialise le composant audio
        partieTerminee = false; //Initialise la variable partieTerminee
        attaquePossible = true; //Initialise la variable attaquePossible

    }


    //D�tection des touches du clavier et modification des vitesses en cons�quence
    // "a" et "d" pour d�placement horizontale et "w" pour sauter

    // Update is called once per frame
    void Update()
    {
        // d�placement vers la gauche
        if (partieTerminee == false) { 
            
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
        if (Input.GetKeyDown("w") && Physics2D.OverlapCircle(transform.position, 0.5f))
        {
            vitesseY = 30f;
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
           
        //Gestion de l'attaque
        if (Input.GetKeyDown(KeyCode.Space) && attaquePossible == true && GetComponent<Animator>().GetBool("saute") == false)
        {
            GetComponent<Animator>().SetBool("attaque", true);
            attaquePossible = false;
            Invoke("AnnuleAttaque", 0.4f);
        } else
        {
            GetComponent<Animator>().SetBool("attaque", false);
        }
        if (attaquePossible == false && vitesseX <= vitesseXMax)
        {
            vitesseX = vitesseX + 5f;
        }


    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //D�sactive l'animation de saut si l'objet touche le sol
        if (Physics2D.OverlapCircle(transform.position, 0.5f))
        {
            GetComponent<Animator>().SetBool("saute", false);
        }

        //Activation de l'animation mort au contact avec un ennemi
        if (collision.gameObject.name == "RoueDentelee")
        {
            GetComponent<Animator>().SetBool("mort", true);

            //D�sactive les contr�les du personnage lorsqu'il est mort
            if (transform.position.x > collision.transform.position.x)
            {
                GetComponent <Rigidbody2D>().velocity = new Vector2(10, 30);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 30);
            }

            //D�clenche son de mort
            sourceAudio.PlayOneShot(sonMort, 1f); //Joue le clip qui se trouve dans la variable sonMort

            //Partie termin�e enregistr�e
            partieTerminee = true;

            //Fin de la partie, reload la scene
            Invoke ("Recommencer", 2f);
        }

        //Sc�ne victoire est activ�e quand le personnage touche l'objet troph�e
        if (collision.gameObject.name == "trophee")
        {
            SceneManager.LoadScene("finaleGagne");
        }

        //Activation de l'animation mort au contact avec un ennemi
        if (collision.gameObject.name == "Abeille")
        {
            GetComponent<Animator>().SetBool("mort", true);
            GetComponent<Animator>().SetBool("explosion", true);

            //D�sactive les contr�les du personnage lorsqu'il est mort
            if (transform.position.x > collision.transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(10, 30);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 30);
            }

            //D�clenche son de mort
            sourceAudio.PlayOneShot(sonMort, 1f); //Joue le clip qui se trouve dans la variable sonMort

            //Partie termin�e enregistr�e
            partieTerminee = true;

            //Fin de la partie, reload la scene
            Invoke("Recommencer", 2f);
        }

        //Si l'ennemi est touch� et on attaque alors l'ennemi mort sinon le personnage est mort, le jeu recommence
        else if (collision.gameObject.tag == "Ennemi")
        {
            if (attaquePossible == true)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                GetComponent<Animator>().SetBool("mort", true);
                sourceAudio.PlayOneShot(sonMort, 1f); //Joue le clip qui se trouve dans la variable sonMort
                Invoke("Recommencer", 2f);
            }
        }

       
        
    }

    //Si le Megaman tombe dans le vide, il meurt et la partie recommence
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Vide")
        {
            //D�clenche l'animation de mort
            GetComponent<Animator>().SetBool("mort", true);

            //Recommence la partie
            Invoke("Recommencer", 2f);
        }
    }

    //Recommen�er la partie
    void Recommencer()
    {
        SceneManager.LoadScene("finaleMort");
    }

    //Annule l'attaque
    void AnnuleAttaque()
    {
        attaquePossible = true;
    }
}