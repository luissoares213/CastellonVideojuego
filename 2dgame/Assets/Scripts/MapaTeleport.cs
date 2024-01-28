using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaTeleport : MonoBehaviour
{
    [SerializeField] private List<Escenario> escenarios;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Escenario escenario in escenarios)
        {
            if (escenario.pulsado)
            {
                SceneManager.LoadScene(escenario.nombreEscenario);
            }
        }
    }
}
