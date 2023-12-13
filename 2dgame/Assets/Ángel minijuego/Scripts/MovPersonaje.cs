using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovPersonaje : MonoBehaviour
{
    public float JumpForce;
    public float JumpForceDown;
    private Rigidbody2D Rigidbody2D;
    private bool Suelo;
    private int Contador;

    public GameObject botonReiniciar;

    private Animator Animator;

    public Button botonSalto;
    public Button botonSaltoBajo;


    private Collider2D miCollider;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        miCollider = GetComponent<Collider2D>();

        Contador = 0;

        Animator = GetComponent<Animator>();

        botonReiniciar.SetActive(false);


        if (botonSalto != null)
        {
            botonSalto.onClick.AddListener(BotonSaltoClick);
        }

        if (botonSaltoBajo != null)
        {
            botonSaltoBajo.onClick.AddListener(BotonSaltoAbajo);
        }

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

    }
    public void BotonSaltoClick()
    {
        if (Contador < 1)
        {
            // Verifica si el jugador est� en el suelo antes de realizar el salto
            if (Suelo)
            {
                Contador++;
                Jump();
                DesactivarColliderPorUnSegundo();
                Animator.SetBool("Saltar", true);
            }
        }
            
    }

    public void BotonSaltoAbajo()
    {
        if (Contador > -1)
        {
            // Verifica si el jugador est� en el suelo antes de realizar el salto
            if (Suelo)
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
        Debug.Log("Colisi�n detectada");
        // Verifica si el collider con el que colisionamos es el personaje
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Detener el tiempo
            Time.timeScale = 0f;

            // El personaje choc� con un obst�culo
            MostrarBotonReiniciar();

            // Puedes agregar aqu� cualquier otra l�gica que desees ejecutar cuando ocurra la colisi�n con el personaje
            Debug.Log("�Colisi�n con el personaje detectada! Tiempo detenido.");
        }
    }


    private void MostrarBotonReiniciar()
    {
        // Asegurarse de que el bot�nReiniciar no sea nulo
        if (botonReiniciar != null)
        {
            // Activar el bot�nReiniciar
            botonReiniciar.SetActive(true);
        }
        else
        {
            Debug.LogError("La referencia al bot�n de reinicio no est� asignada en el Inspector.");
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
