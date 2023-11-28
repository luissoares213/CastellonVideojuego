using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReiniciarJuego : MonoBehaviour
{
    // Método que se llama cuando el botón es presionado
    public void OnReiniciarClick()
    {
        // Reiniciar el tiempo
        Time.timeScale = 1f;

        // Cargar la escena actual (esto reinicia el juego)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Método para ocultar el botón
    private void OcultarBoton()
    {
        GetComponent<Button>().interactable = false;
        GetComponent<Image>().enabled = false; // Esto oculta la imagen del botón
        GetComponentInChildren<Text>().enabled = false; // Esto oculta el texto del botón (si lo tiene)
    }

    // Método para mostrar el botón
    private void MostrarBoton()
    {
        GetComponent<Button>().interactable = true;
        GetComponent<Image>().enabled = true;
        GetComponentInChildren<Text>().enabled = true;
    }



    // Start is called before the first frame update
    void Start()
    {
        OcultarBoton();
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si el tiempo está detenido
        if (Time.timeScale == 0f)
        {
            // Si el tiempo está detenido, muestra el botón
            MostrarBoton();
        }
        else
        {
            // Si el tiempo está en curso, oculta el botón
            OcultarBoton();
        }
        
    }
}
