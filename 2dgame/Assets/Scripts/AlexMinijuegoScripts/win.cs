using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public SceneInfo scene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key")) //Detectar si es el bloque llave
        {
            //Codigo de ganar

            SceneManager.LoadScene(scene.volver);
            //Debug.Log("Win"); 
        }
        else //<-- No hace falta
        {
            //Debug.Log("Not quite");
        }
    }
}
