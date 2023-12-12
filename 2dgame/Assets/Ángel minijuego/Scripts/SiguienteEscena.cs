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
        // Desactiva el botón al inicio
        boton.gameObject.SetActive(false);
    }

    public void CargarSiguienteEscena()
    {
        // Aquí defines la lógica para cargar la siguiente escena
        // Asegúrate de que las escenas estén configuradas en Build Settings
        SceneManager.LoadScene("Museo");
    }
}
