using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampanaController : MonoBehaviour
{
    public MinijuegoController minijuegoScript;
    public int panesColocados = 0;
    public AudioSource Ding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio() 
    {
        Ding.Play();
    }

    public void OnMouseDown() {
        Ding.Play();    
        minijuegoScript.borrarPanes();
        panesColocados = 0;
        
    }
}
