using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovPersonaje : MonoBehaviour
{
    public float JumpForce;
    public float JumpForceDown;
    private Rigidbody2D Rigidbody2D;
    private bool Suelo;
    private int Contador;

    public GameObject botonReiniciar;

    private Animator Animator;


    private Collider2D miCollider;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        miCollider = GetComponent<Collider2D>();

        Contador = 0;

        Animator = GetComponent<Animator>();

        botonReiniciar.SetActive(false);
    }


    void Update()
    {

        //Debug.DrawRay(transform.position, Vector3.down * 10f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 8f))
        {
            Suelo = true;
            Animator.SetBool("Saltar", false);
        }
        else
        {
            Suelo = false;
        }

        if (Contador < 1)
        {
            if (Input.GetKeyDown(KeyCode.W) && Suelo)
            {
                Contador++;
                Jump();
                DesactivarColliderPorUnSegundo();
                Animator.SetBool("Saltar", true);
            }
        }

        if (Contador > -1)
        {
            if (Input.GetKeyDown(KeyCode.S) && Suelo)
            {
                Contador--;
                JumpDown();
                DesactivarColliderPorUnSegundo();
                Animator.SetBool("Saltar", true);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión detectada");
        // Verifica si el collider con el que colisionamos es el personaje
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Detener el tiempo
            Time.timeScale = 0f;

            // El personaje chocó con un obstáculo
            MostrarBotonReiniciar();

            // Puedes agregar aquí cualquier otra lógica que desees ejecutar cuando ocurra la colisión con el personaje
            Debug.Log("¡Colisión con el personaje detectada! Tiempo detenido.");
        }
    }


    private void MostrarBotonReiniciar()
    {
        // Asegurarse de que el botónReiniciar no sea nulo
        if (botonReiniciar != null)
        {
            // Activar el botónReiniciar
            botonReiniciar.SetActive(true);
        }
        else
        {
            Debug.LogError("La referencia al botón de reinicio no está asignada en el Inspector.");
        }
    }

    public void ReiniciarPartida()
    {
        // Reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    void DesactivarColliderPorUnSegundo()
    {
        miCollider.enabled = false;
        Invoke("ActivarCollider", 0.3f);
    }

    void ActivarCollider()
    {
        miCollider.enabled = true;
    }


    private void JumpDown()
    {
        Rigidbody2D.AddForce(Vector2.down * JumpForceDown);
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
}
