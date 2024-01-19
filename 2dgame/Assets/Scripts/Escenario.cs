using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escenario : MonoBehaviour
{
    // Start is called before the first frame update
    public string nombreEscenario;
    public bool pulsado;
    void Start()
    {
        pulsado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pulsado()
    {
        pulsado = true;
    }

}
