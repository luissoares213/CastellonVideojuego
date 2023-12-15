using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key")) //Detectar si es el bloque llave
        {
            //Codigo de ganar

            SceneManager.LoadScene("Escena 3-Ermita 1");
            //Debug.Log("Win"); 
        }
        else //<-- No hace falta
        {
            //Debug.Log("Not quite");
        }
    }
}
