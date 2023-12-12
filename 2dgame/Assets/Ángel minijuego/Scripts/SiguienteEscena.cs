using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SiguienteEscena : MonoBehaviour
{
    public Button boton;

    private void Start()
    {
        // Desactiva el bot�n al inicio
        boton.gameObject.SetActive(false);
    }

    public void CargarSiguienteEscena()
    {
        // Aqu� defines la l�gica para cargar la siguiente escena
        // Aseg�rate de que las escenas est�n configuradas en Build Settings
        SceneManager.LoadScene("Museo");
    }
}
