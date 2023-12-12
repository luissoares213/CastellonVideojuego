using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterM : MonoBehaviour
{
    private int csInd;
    [SerializeField] private string Minijuego;
    public SceneInfo sceneInfo;
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
}
