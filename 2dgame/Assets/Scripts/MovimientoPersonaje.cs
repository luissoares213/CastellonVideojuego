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
        // Almacenar la posición inicial del personaje al inicio
        posicionInicial = transform.position;
        posY = posicionInicial.y; // Establecer la posición y inicial
        posX = posicionInicial.x; //Establecer la posición x inicial
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
        // Mover el personaje hacia la posición inicial en el eje y y la posición deseada en el eje x
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(posicionX, posY), Time.deltaTime * speed);
    }
}


