using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistas : MonoBehaviour
{
    [SerializeField] private GameObject ContPistas;
    [SerializeField] private List<GameObject> pista;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PedirPista()
    {
        for (int i = 0; i < pista.Count; i++)
        {
            if (pista[i].activeInHierarchy == false) {
                pista[i].SetActive(true);
                break;
            }
        }
    }
    public void MostrarPistas() 
    {
        if (ContPistas.activeInHierarchy==false)
        {
            ContPistas.SetActive(true);
        }
        else
        {
            ContPistas.SetActive(false);
        }
        


    }
}
