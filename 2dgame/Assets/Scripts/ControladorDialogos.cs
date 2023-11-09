using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDialogos : MonoBehaviour
{
    public static bool diAct = false;
    
    public void DiActChange(bool f)
    {
        diAct = f;
    }
    public bool DiAct() { return diAct; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
