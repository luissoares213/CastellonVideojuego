using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpS : MonoBehaviour
{
    [SerializeField] private Dialog dial;
    [SerializeField] private CarasTexto caraTexto;
    // Start is called before the first frame update
    void Start()
    {
        dial.enabled = false;
        caraTexto.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
