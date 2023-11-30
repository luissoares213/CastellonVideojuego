using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveB : MonoBehaviour
{
    public MoveA p; //Personaje que se mueve (Ha de tener el script MoveA)
    public GameObject q; //Destino del personaje que se mueve
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
        p.gameObject.GetComponent<MoveA>().moving(q.transform.position, this.gameObject);
    }
}
