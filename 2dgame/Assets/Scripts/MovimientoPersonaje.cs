using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour
{
    public float speed = 5.0f;
    private float posY;
    private float posX;
    private Vector2 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        // Almacenar la posici�n inicial del personaje al inicio
        posicionInicial = transform.position;
        posY = posicionInicial.y; // Establecer la posici�n y inicial
        posX = posicionInicial.x; //Establecer la posici�n x inicial
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            posX = mousePos.x;
        }

        MoverPersonaje(posX);
    }

    void MoverPersonaje(float posicionX)
    {
        // Mover el personaje hacia la posici�n inicial en el eje y y la posici�n deseada en el eje x
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(posicionX, posY), Time.deltaTime * speed);
    }
}


