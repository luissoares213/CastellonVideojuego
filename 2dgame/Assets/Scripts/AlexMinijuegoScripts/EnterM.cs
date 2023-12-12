using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterM : MonoBehaviour
{
    private int csInd;
    [SerializeField] private string Minijuego;
    public SceneInfo sceneInfo;
    [SerializeField] private int newActo;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void EnterGame()
    {
        
        sceneInfo.acto = newActo;
        csInd = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", csInd);
        SceneManager.LoadScene(Minijuego);
    }
}
