using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreerEnnemis : MonoBehaviour
{
    public GameObject ennemiACreer; //La roue
    public GameObject personnage; //Position de Megaman
    public float limiteGauche; //Zone de génération
    public float limiteDroite;

    void Start()
    {
        //Appel de la fonction DupliqueRoue
        InvokeRepeating("DupliqueRoue", 0, 3);
    }

    //Fonction pour dupliquer la roue
    void DupliqueRoue()
    {
        //S'assurer que Megaman est dans la zone de génération
        if (personnage.transform.position.x > limiteGauche && personnage.transform.position.x < limiteDroite)
        {
            //Créer une nouvelle roue
            GameObject gameObject = Instantiate(ennemiACreer);

            //Acitivez le clone
            ennemiACreer.SetActive(true);

            //Positionnez le clone avec une position Y: en haut de la scène
            gameObject.transform.position = new Vector3(Random.Range(limiteGauche, limiteDroite), 10, 0);

            //Position aléatoire en X
            gameObject.transform.position = new Vector3(Random.Range(limiteGauche, limiteDroite), 10, 0);
        }
    }
}
