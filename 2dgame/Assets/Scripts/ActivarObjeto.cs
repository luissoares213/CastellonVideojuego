using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{
    [SerializeField] private GameObject activar;

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
        activar.SetActive(true);


    }
    public void Activar() {
        activar.SetActive(true);
    }
    public void Desactivar() {
        activar.SetActive(false);
    }
}
