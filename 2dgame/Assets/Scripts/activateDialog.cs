using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateDialog : MonoBehaviour
{
    [SerializeField] private GameObject primero;
    [SerializeField] private GameObject segundo;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
            

    }
    public void cambio()
    {
        print("cebolla");
        primero.SetActive(false);
        segundo.SetActive(true);

    }
}
