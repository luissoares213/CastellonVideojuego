using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarasTexto : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject caraDerecha;
    [SerializeField] private GameObject caraIzquierda;
    [SerializeField] private Dialog eventosDialogo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (eventosDialogo.lineIndex % 2 == 0)
        {
            caraDerecha.GetComponent<Image>().color = Color.white;
            caraIzquierda.GetComponent<Image>().color = Color.grey;

        }
        else
        {
            caraIzquierda.GetComponent<Image>().color = Color.white;
            caraDerecha.GetComponent<Image>().color = Color.grey;
        }
        if (eventosDialogo.controlDial.DiAct() == false)
        {
            caraIzquierda.SetActive(false);
        }

    }
    private void OnMouseDown()
    {
        caraIzquierda.SetActive(true);
    }
}
