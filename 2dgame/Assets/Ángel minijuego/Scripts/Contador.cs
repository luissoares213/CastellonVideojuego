using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Text contadorText;
    public float tiempoLimite = 60f;
    private float tiempoRestante;
    public SiguienteEscena scriptBoton;  // Agrega una referencia a tu script del bot�n aqu�

    void Start()
    {
        tiempoRestante = tiempoLimite;
        scriptBoton = FindObjectOfType<SiguienteEscena>();  // Encuentra autom�ticamente el script del bot�n
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        contadorText.text = "Tiempo: " + Mathf.Round(tiempoRestante).ToString();

        if (tiempoRestante <= 0f)
        {
            Debug.Log("�Tiempo agotado!");
            Time.timeScale = 0f;
            scriptBoton.boton.gameObject.SetActive(true);  // Activa el bot�n cuando el tiempo llega a cero
        }
    }
}
