using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReiniciarJuego : MonoBehaviour
{
    // M�todo que se llama cuando el bot�n es presionado
    public void OnReiniciarClick()
    {
        // Reiniciar el tiempo
        Time.timeScale = 1f;

        // Cargar la escena actual (esto reinicia el juego)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // M�todo para ocultar el bot�n
    private void OcultarBoton()
    {
        GetComponent<Button>().interactable = false;
        GetComponent<Image>().enabled = false; // Esto oculta la imagen del bot�n
        GetComponentInChildren<Text>().enabled = false; // Esto oculta el texto del bot�n (si lo tiene)
    }

    // M�todo para mostrar el bot�n
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
        // Verifica si el tiempo est� detenido
        if (Time.timeScale == 0f)
        {
            // Si el tiempo est� detenido, muestra el bot�n
            MostrarBoton();
        }
        else
        {
            // Si el tiempo est� en curso, oculta el bot�n
            OcultarBoton();
        }
        
    }
}
