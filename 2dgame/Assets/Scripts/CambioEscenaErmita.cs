using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CambioEscenaErmita : MonoBehaviour
{
    public string EscenaErmita;
    void CambiarEscena()
    {
        // Cambia a la nueva escena
        SceneManager.LoadScene(EscenaErmita);
    }

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
