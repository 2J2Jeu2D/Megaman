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
            Destroy(collision.gameObject); // Destroy the enemy
            Invoke("Detruire", 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("DetruireBalle", 0.15f);

        if (collision.gameObject.tag == "Ennemis")
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            if (collision.gameObject.transform.parent != null) // Check if the game object has a parent
            {
                parent = collision.gameObject.transform.parent.gameObject;
                Invoke("DetruireParent", 0.5f); // Destroy the parent (the game object itself is destroyed when the parent is destroyed
            }
            else
            {
                Destroy(collision.gameObject); // Destroy the game object itself if it has no parent
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