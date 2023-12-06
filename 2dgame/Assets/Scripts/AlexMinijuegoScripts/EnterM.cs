using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterM : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer l;
    private int csInd;
    public SceneInfo sceneInfo;
    Color c = Color.red;
    void Start()
    {
        if (sceneInfo.acto == 3) {
            l.color = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        
        sceneInfo.acto = 2;
        csInd = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", csInd);
        SceneManager.LoadScene("Alex Minijuego");
    }
}
