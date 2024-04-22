using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSuivi : MonoBehaviour
{
    public GameObject CibleSuivre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionActuelle = transform.position;
        positionActuelle.x = CibleSuivre.transform.position.x;
        transform.position = positionActuelle;
    }
}
