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

    // Détecte les collisions
    // Active l'animation de l'objet quand il est touché
    // Détruit l'objet après un délai (à la fin de l'animation)
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Megaman")
        {
            //Désactiver le collider 2d de la roue dentelée
            GetComponent<Collider2D>().enabled = false;

            //Mettre la vélocité de la roue dentelée à 0 dans les deux axes
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            //Mettre la velocité angulaire de la roue dentelée à 0
            GetComponent<Rigidbody2D>().angularVelocity = 0;

            //Désactiver la gravité de la roue dentelée
            GetComponent<Rigidbody2D>().gravityScale = 0;

            //si le personnage est touché alors active l'animation de l'objet et détruit le
            GetComponent<Animator>().enabled = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
