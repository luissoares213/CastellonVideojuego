using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float speed = 15f; // Velocidad de movimiento del personaje
    private bool isMoving = false; // Bandera para verificar si el personaje se está moviendo
    private Vector2 targetPosition; // Posición objetivo del personaje
    private Vector3 originalScale;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Detectar el clic del mouse
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("ClickableObject"))
            {
                // Si se hace clic en un objeto con la etiqueta "ClickableObject"
                targetPosition = new Vector2(hit.collider.transform.position.x, transform.position.y);
                isMoving = true;
                animator.SetBool("Andar", true);
                // Girar el personaje según la dirección
                FlipCharacter(targetPosition.x > transform.position.x);
            }
        }

        if (isMoving)
        {
            // Mover el personaje solo en el eje X hacia la posición objetivo
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Verificar si el personaje ha llegado a la posición objetivo
//Updated upstream
            if (Vector2.Distance(transform.position, targetPosition) < 10f)

            if (Vector2.Distance(transform.position, targetPosition) < 5f)
//Stashed changes
            {
                isMoving = false;
                animator.SetBool("Andar", false);
                
            }
        }     
    }
    // Método para girar el personaje
    void FlipCharacter(bool isFacingRight)
    {
        if (isFacingRight)
        {
            transform.localScale = originalScale;
        }
        else
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
    }
}


