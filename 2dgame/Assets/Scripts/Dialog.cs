using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [Header("Atributes")]
    //[SerializeField] private int dialogoMostrar = 0;  //El dialogo que se mostrará, diferentes dialogos se referenciarán con diferentes números.
    //Para que el sprite cambie de color cuando el mouse se ponga encima.

    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private TMP_Text Texto;
    [SerializeField] private GameObject GloboTexto;
    [SerializeField, TextArea(4, 6)] private string[] LineasDialogo; //El 4 y el 6 es el espacio de las lineas.


    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color startColor;

    [SerializeField] private GameObject globoTexto;

    private float TiempoTapeo = 0.05f;
    private bool EmpezoDialogo;
    private int lineIndex;

    /*private void OnMouseDown()
    {
        //Dialogar(dialogoMostrar);

    }*/
    private void Dialogar(/*Para saber que dialogo mostrar.*/ int d ) 
    {

        globoTexto.SetActive(true);// Mostramos el globo de texto.


    }

    // Start is called before the first frame update
    void Start()
    {
        startColor = sr.color;
    }
    //Para que el sprite cambie de color cuando el mouse se ponga encima.
    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }
    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(sr.color == hoverColor && Input.GetButtonDown("Fire1"))
        {
            if (!EmpezoDialogo)
            {
                StartDialogue();
            }
            else if (Texto.text == LineasDialogo[lineIndex])
            {
                SiguienteLineaDialogo();
            }
            else//adelantar lineas de dialogo
            {
                StopAllCoroutines();
                Texto.text = LineasDialogo[lineIndex];
            }
            
        }
    }

    private void StartDialogue()
    {
        EmpezoDialogo = true;
        GloboTexto.SetActive(true);
        //dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void SiguienteLineaDialogo()
    {
        lineIndex++;
        if (lineIndex < LineasDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            EmpezoDialogo = false;
            GloboTexto.SetActive(false);
            //dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    //Tipear los diferentes carácteres del diálogo hasta terminar con la linea de dialogo.
    private IEnumerator ShowLine()
    {
        Texto.text = string.Empty;
        foreach(char ch in LineasDialogo[lineIndex])
        {
            Texto.text += ch;
            yield return new WaitForSecondsRealtime(TiempoTapeo);
        }
    }
}
