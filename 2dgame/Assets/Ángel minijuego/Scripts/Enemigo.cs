using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject prefabObjeto;
    public Transform posicion1;
    public Transform posicion2;
    public Transform posicion3;
    public float velocidad = 5f;

    void Start()
    {
        GenerarYUbicarObjeto();
    }


    void GenerarYUbicarObjeto()
    {
        // Elije una posición aleatoria entre las tres
        int indicePosicionAleatoria = Random.Range(0, 3);

        // Selecciona la posición según el índice aleatorio
        Vector3 posicionElegida = indicePosicionAleatoria == 0 ? posicion1.position :
                                   indicePosicionAleatoria == 1 ? posicion2.position :
                                   posicion3.position;

        // Instancia el prefab en la posición elegida
        GameObject objetoInstanciado = Instantiate(prefabObjeto, posicionElegida, Quaternion.identity);

        // Asigna este objeto como hijo del Generador para gestionar su movimiento
        objetoInstanciado.transform.parent = transform;
    }

    void Update()
    {
        MoverObjetoHaciaIzquierda();
    }

    void MoverObjetoHaciaIzquierda()
    {
        // Mueve todos los objetos hijos hacia la izquierda
        foreach (Transform hijo in transform)
        {
            hijo.Translate(Vector3.left * velocidad * Time.deltaTime);

            // Verifica si el objeto ha salido completamente de la pantalla
            if (hijo.position.x < -10f)
            {
                // Destruye el objeto actual
                Destroy(hijo.gameObject);

                // Genera y ubica un nuevo objeto
                GenerarYUbicarObjeto();
            }

        }
    }
}
