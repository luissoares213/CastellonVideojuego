using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] private int dialogoMostrar = 0;  //El dialogo que se mostrará, diferentes dialogos se referenciarán con diferentes números.
    //Para que el sprite cambie de color cuando el mouse se ponga encima.
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color startColor;

    [SerializeField] private GameObject globoTexto;
    private void OnMouseDown()
    {
        Dialogar(dialogoMostrar);

    }
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
        
    }
}
