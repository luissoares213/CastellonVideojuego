using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public SceneInfo sceneinfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key")) //Detectar si es el bloque llave
        {
            //Codigo de ganar
            sceneinfo.acto = 3;
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
            Debug.Log("Win"); 
        }
        else //<-- No hace falta
        {
            Debug.Log("Not quite");
        }
    }
}
