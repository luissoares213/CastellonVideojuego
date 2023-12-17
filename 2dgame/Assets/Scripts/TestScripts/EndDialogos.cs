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
    }


}
