using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Text contadorText;
    public float tiempoLimite = 60f; // Establece el tiempo límite en segundos
    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = tiempoLimite;
    }

    void Update()
    {
        // Actualiza el contador
        tiempoRestante -= Time.deltaTime;

        // Actualiza el texto del contador
        contadorText.text = "Tiempo: " + Mathf.Round(tiempoRestante).ToString();

        // Puedes agregar lógica adicional aquí, como manejar eventos cuando el contador llega a cero
        if (tiempoRestante <= 0f)
        {
            Debug.Log("¡Tiempo agotado!");
            // Aquí puedes agregar código para manejar el evento cuando el tiempo llega a cero
            Time.timeScale = 0f;
        }
    }
}
