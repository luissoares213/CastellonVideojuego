using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [Header("Atributes")]
    //[SerializeField] private int dialogoMostrar = 0;  //El dialogo que se mostrará, diferentes dialogos se referenciarán con diferentes números.
    //Para que el sprite cambie de color cuando el mouse se ponga encima.

    [SerializeField] private TMP_Text Texto;
    [SerializeField] private GameObject GloboTexto;
    [SerializeField, TextArea(4, 6)] private string[] LineasDialogo; //El 4 y el 6 es el espacio de las lineas.
    [SerializeField] private GameObject plyr;
    [SerializeField] private int accionEnd;

    [SerializeField] private GameObject globoTexto;

    private float TiempoTapeo = 0.05f;
    private bool EmpezoDialogo;
    public ControladorDialogos controlDial;
    public int lineIndex;

    

    // Start is called before the first frame update
    void Start()
    {
        controlDial = FindObjectOfType<ControladorDialogos>();
    }
    //Para que el sprite cambie de color cuando el mouse se ponga encima.
    private void OnMouseDown()
    {
        if (!controlDial.DiAct() || EmpezoDialogo)
        { 
            if (!EmpezoDialogo)
            {
                //IniciarDialogo();
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
    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarDialogo()
    {
        EmpezoDialogo = true;
        controlDial.DiActChange(EmpezoDialogo);
        GloboTexto.SetActive(true);
        //dialogueMark.SetActive(false);
        lineIndex = 0;
        //Time.timeScale = 0f;
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
            controlDial.DiActChange(EmpezoDialogo);
            GloboTexto.SetActive(false);
            //dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            plyr.GetComponent<MoveA>().Chbla(false);
            
            if (GetComponent<EnterM>()) 
            {
                GetComponent<EnterM>().EnterGame();
            }
            if (GetComponent<EndDialogos>())
            {
                GetComponent<EndDialogos>().EndDial(accionEnd);
            }
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
