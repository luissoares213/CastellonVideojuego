using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveA : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 dest;
    private Vector3 mov;
    private Animator animator;
    private bool talk;
    // Start is called before the first frame update
    void Start()
    {
        talk = false;
        dest = this.transform.position;
        mov = this.transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mov != dest) { 
            animator.SetBool("Andar", true);
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
        else { 
            animator.SetBool("Andar", false); 
            if (talk)
            {
                //Talking Code;
                Debug.Log("talk");
                talk = false; 
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
        mov = transform.position;
    }
    public void moving(Vector3 a)
    {
        dest = a;
        talk = true;
    }
}
