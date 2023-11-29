using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour
{
    public Transform objetivo; // El objeto al que el personaje se moverá
    public float velocidadMovimiento = 5f;

    private bool estaEnMovimiento = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !estaEnMovimiento)
        {
            // Verificar si se hizo clic en el objetivo
            if (ClicEnObjetivo())
            {
                // Iniciar el movimiento del personaje solo si se hizo clic en el objetivo
                estaEnMovimiento = true;

                // Girar hacia la dirección del clic si es necesario
                GirarHaciaClic();
            }
        }

        if (estaEnMovimiento)
        {
            MoverPersonaje();
        }
    }

    void MoverPersonaje()
    {
        // Calcular la dirección hacia el objetivo solo en el eje x
        Vector3 direccion = new Vector3(objetivo.position.x - transform.position.x, 0, 0).normalized;

        // Mover directamente hacia el objetivo
        transform.position += direccion * velocidadMovimiento * Time.deltaTime;

        // Verificar si ha alcanzado el objetivo
        if (Mathf.Abs(transform.position.x - objetivo.position.x) < 4f)
        {
            // Detener el movimiento cuando alcanza el objetivo
            estaEnMovimiento = false;
        }
    }

    void GirarHaciaClic()
    {
        // Verificar si el clic ocurrió a la izquierda del personaje y está mirando hacia la derecha
        if (Input.mousePosition.x < Camera.main.WorldToScreenPoint(transform.position).x && transform.localScale.x > 0)
        {
            // Girar el personaje hacia la izquierda
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    bool ClicEnObjetivo()
    {
        // Verificar si el clic ocurrió dentro del área del collider del objetivo
        Collider2D objetivoCollider = objetivo.GetComponent<Collider2D>();
        if (objetivoCollider != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return objetivoCollider.OverlapPoint(mousePos);
        }
        return false;
    }
}


