using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCam : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;

    // Start is called before the first frame update
    void Start()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) //touche 1 en haut du clavier
        {
            Camera1.SetActive(true);
            Camera2.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) //touche 2 en haut du clavier
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
        }
    }
}
