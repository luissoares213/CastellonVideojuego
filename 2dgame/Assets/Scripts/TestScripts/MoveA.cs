using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveA : MonoBehaviour
{
    private float speed = 5f;
    public Vector3 dest;
    private Vector3 mov;
    private Animator animator;
    private bool talk;
    private bool hablando;
    public GameObject h;
    private int Cont=0;
    // Start is called before the first frame update
    void Start()
    {
        hablando = false;
        talk = false;
        dest = this.transform.position;
        mov = this.transform.position;
        this.transform.position = dest;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mov != dest) { 
            animator.SetBool("Andar", true);
            
        }
        else { 
            animator.SetBool("Andar", false); 
            if (talk)
            {
                h.GetComponent<Dialog>().IniciarDialogo();
                hablando = true;
                //Talking Code;
                //Debug.Log("talk");

                talk = false;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
        mov = transform.position;
    }
    public void moving(Vector3 a, GameObject j)
    {
        dest = a;
        if (hablando != true)
        {
            if (Cont == 0)
                talk = true;
            else if(Cont==1){ Cont = 0; }
        }
        h = j;
        if (Input.mousePosition.x < Camera.main.WorldToScreenPoint(transform.position).x && transform.localScale.x > 0)
        {
            // Girar el personaje hacia la izquierda
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            animator.SetBool("GirarIzquierda", true);
        }
        else
        {
            // Cambiar el parámetro "GirarIzquierda" en el Animator a false
            animator.SetBool("GirarIzquierda", false);
        }
    }
    public void Chbla(bool b)
    {
        hablando = b;
        Cont = 1;
    }
}
