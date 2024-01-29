using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndDialogos : MonoBehaviour
{
    [SerializeField] private AudioClip sonido;
    [SerializeField] private AudioSource so;
    [SerializeField] private Dialog dial;
    [SerializeField] private CarasTexto caraTexto;
    [SerializeField] private string volver;
    [SerializeField] private GameObject video; 

    [SerializeField] private GameObject primero;
    [SerializeField] private GameObject segundo;
    [SerializeField] private GameObject boton;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private CarasTexto ct;
    public void FinVideo(VideoPlayer vp) {
        video.SetActive(false);
        so.clip = sonido;
        so.Play();
        dial.enabled = true;
        caraTexto.enabled = true;
        dial.IniciarDialogo();
    }
    public void EndDial(int accionEnd)
    {
        if (accionEnd == 1)
        {
            video.SetActive(true);
            video.GetComponent<VideoPlayer>().Play();
            video.GetComponent<VideoPlayer>().loopPointReached += FinVideo;
            

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
        else if (accionEnd == 4)
        {
            GetComponent<EnterM>().MinijuegoYVolver(volver);
        }
        else if (accionEnd == 5) {
            bc.enabled = true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            ct.enabled = true;
        }
        else if (accionEnd == 6)
        {
            dial.enabled = true;
            caraTexto.enabled = true;
            dial.IniciarDialogo();
        }

    }


}
