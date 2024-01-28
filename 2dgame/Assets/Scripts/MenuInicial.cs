using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public SceneInfo sceneInfo;
    private void Start()
    {
        sceneInfo.volver = "MenuInicial";
    }
    public void Jugar()
    {
        sceneInfo.cameraPos = new Vector3(0, 0, -10);
        sceneInfo.acto = 0;
        sceneInfo.periDest = new Vector3(22, -15, 0);
        sceneInfo.periMov = sceneInfo.periDest;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
