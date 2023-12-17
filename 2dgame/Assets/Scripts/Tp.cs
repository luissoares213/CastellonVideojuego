using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tp : MonoBehaviour
{
    public string nombreDeEscena;
    public void tepear()
    {
        print(nombreDeEscena);
        SceneManager.LoadScene(nombreDeEscena);
    }
    
}
