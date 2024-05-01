using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBalle : MonoBehaviour
{
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("DetruireBalle", 0.15f);
        GetComponent<Animator>().enabled = true;

        if (collision.gameObject.tag == "Ennemis")
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            Destroy(collision.gameObject); // Détruit l'ennemi
            Invoke("Detruire", 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("DetruireBalle", 0.15f);

        if (collision.gameObject.tag == "Ennemis")
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            if (collision.gameObject.transform.parent != null) // Check si le parent existe
            {
                parent = collision.gameObject.transform.parent.gameObject;
                Invoke("DetruireParent", 0.5f); // Détruire le parent
            }
            else
            {
                Destroy(collision.gameObject); // Détruire l'ennemi
            }
        }
    }

    void DetruireBalle()
    {
        Destroy(gameObject);
    }

    void Detruire()
    {
        Destroy(gameObject);
    }

    void DetruireParent()
    {
        Destroy(parent);
    }
}