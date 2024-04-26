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
            Instantiate(ennemiACreer, new Vector3(personnage.transform.position.x + 10, 0, 0), Quaternion.identity);

            //Acitivez le clone
            ennemiACreer.SetActive(true);

            //Positionnez le clone avec une position Y: en haut de la scène

            //Position aléatoire en X
        }
    }
}
