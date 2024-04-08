using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // D�tecte les collisions
    // Active l'animation de l'objet quand il est touch�
    // D�truit l'objet apr�s un d�lai (� la fin de l'animation)
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Megaman")
        {
            //D�sactiver le collider 2d de la roue dentel�e
            GetComponent<Collider2D>().enabled = false;

            //Mettre la v�locit� de la roue dentel�e � 0 dans les deux axes
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            //Mettre la velocit� angulaire de la roue dentel�e � 0
            GetComponent<Rigidbody2D>().angularVelocity = 0;

            //D�sactiver la gravit� de la roue dentel�e
            GetComponent<Rigidbody2D>().gravityScale = 0;

            //si le personnage est touch� alors active l'animation de l'objet et d�truit le
            GetComponent<Animator>().enabled = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
