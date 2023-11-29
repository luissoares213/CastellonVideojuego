using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControler : MonoBehaviour
{
    [Header ("Atrib")]
    [SerializeField] public float initialPositionX; //Posiciones iniciales para reubicarlos
    [SerializeField] public float initialPositionY; //Posiciones iniciales para reubicarlos
    [SerializeField] private float speed = 5f; 
    [SerializeField] private bool grabbed=false; // Si está seleccionado
    [SerializeField] private Rigidbody2D rb;

    private float startPositionX;
    private float startPositionY;
    private Vector3 mousePos;
    [SerializeField] private reseter r; //Para resetearlos a la posición inicial

    private void Start()
    {
        rb.bodyType = RigidbodyType2D.Static; //Para que los otros bloques no lo desplacen
        initialPositionX = transform.position.x;
        initialPositionY= transform.position.y;
        mousePos = transform.position;
        r.gameObject.GetComponent<reseter>().blocks.Add(this); //Añadir el bloque a una lista con todos los bloques
    }
    void Update()
    {
        if (grabbed)
        {
            
            
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Posicion del ratón
            mousePos.z = transform.position.z; //Mantener la profundidad.
            mousePos = new Vector3(mousePos.x - startPositionX, mousePos.y - startPositionY, 0); // Para poder agarrar el bloque desde cualquier parte sin que se teletransporte

                
            
            transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);  //Mover el bloque a la posición del ratón
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) { // Detectar si lo estamos agarrando
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPositionX = mousePos.x - this.transform.localPosition.x; 
            startPositionY = mousePos.y - this.transform.localPosition.y;

            grabbed = true;
            rb.bodyType = RigidbodyType2D.Dynamic; //Para que al colisionar con otros bloques no los atraviese
        }
    }
    private void OnMouseUp()
    {
        rb.bodyType = RigidbodyType2D.Static; //Para que los otros bloques no lo desplacen
        grabbed = false;
    }

    public void ResetearPos()
    {
        transform.position = new Vector3(initialPositionX, initialPositionY, 0); //Volver a la posición inicial
    }


}
