using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDialogos : MonoBehaviour
{
    [SerializeField] private AudioClip sonido;
    [SerializeField] private AudioSource so;
    [SerializeField] private Dialog dial;
    [SerializeField] private CarasTexto caraTexto;

    [SerializeField] private GameObject primero;
    [SerializeField] private GameObject segundo;
    [SerializeField] private GameObject boton;

    public void EndDial(int accionEnd)
    {
        if (accionEnd == 1)
        {
            so.clip = sonido;
            so.Play();
            dial.enabled = true;
            caraTexto.enabled = true;
            dial.IniciarDialogo();

        }
        else if (accionEnd == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (accionEnd == 3)
        {
            primero.SetActive(false);
            segundo.SetActive(true);
            boton.SetActive(true);
        }
    }


}
