using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveB : MonoBehaviour
{
    public MoveA personajeMovible; //Personaje que se mueve (Ha de tener el script MoveA)
    public GameObject destino; //Destino del personaje que se mueve
    public int actoActivo;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnMouseDown()
    {
        personajeMovible.gameObject.GetComponent<MoveA>().moving(destino.transform.position, this.gameObject);
    }
}
