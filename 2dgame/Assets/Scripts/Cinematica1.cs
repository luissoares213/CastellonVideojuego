using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematica1 : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<Dialog>().IniciarDialogo();
        
    }

}
