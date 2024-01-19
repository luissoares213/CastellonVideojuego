using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterM : MonoBehaviour
{
    private int csInd;
    [SerializeField] private string Minijuego;
    public SceneInfo scene;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterGame()
    {
        
        csInd = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", csInd);
        SceneManager.LoadScene(Minijuego);
    }
    public void MinijuegoJoel(string Volver) 
    {
        scene.volver = Volver;
        SceneManager.LoadScene("JoelMinijuego");
    }
    public void MinijuegoAlex(string Volver)
    {
        scene.volver = Volver;
        SceneManager.LoadScene("Alex Minijuego");
    }
}
