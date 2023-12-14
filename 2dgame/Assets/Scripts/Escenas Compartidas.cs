using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasCompartidas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Escena1", LoadSceneMode.Additive);

        SceneManager.LoadScene("Nevera1", LoadSceneMode.Additive);

        SceneManager.LoadScene("Ermita1", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
