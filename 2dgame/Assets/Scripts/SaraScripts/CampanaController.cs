using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampanaController : MonoBehaviour
{
    public MinijuegoController minijuegoScript;
    public int panesColocados = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        minijuegoScript.borrarPanes();
        panesColocados = 0;
    }
}
