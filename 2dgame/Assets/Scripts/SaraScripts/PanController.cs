using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanController : MonoBehaviour
{
    public bool bandejaCorrecta;
    // Start is called before the first frame update
    void Start()
    {
        bandejaCorrecta = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag() {
        Vector3 posicion=posicionMouse();
        transform.position=new Vector3(posicion.x, posicion.y, transform.position.z);

    }

    Vector3 posicionMouse()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    } 

    void OnTriggerEnter2D(Collider2D bandeja) {
        if ((bandeja.tag == "bandeja1" && this.tag == "pan1") ||
            (bandeja.tag == "bandeja2" && this.tag == "pan2") ||
            (bandeja.tag == "bandeja3" && this.tag == "pan3")) {
            bandejaCorrecta = true;
        }
    }

    void OnTriggerExit2D(Collider2D bandeja) {
        if (bandeja.tag == "bandeja1" ||
            bandeja.tag == "bandeja2" ||
            bandeja.tag == "bandeja3") {
            bandejaCorrecta = false;
        }
    }
}
