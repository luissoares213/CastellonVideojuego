using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MinijuegoController : MonoBehaviour
{
    public GameObject Pan1;
    public GameObject Pan2;
    public GameObject Pan3;

    //Adicion de Alex C
    [SerializeField] private SceneInfo scene;

    public TMP_Text puntosText;
    public TMP_Text tiempoText;
    
    float tiempo = 180;
    int puntos = 0;

    GameObject[] panes = new GameObject[5] {null, null, null, null, null};
    // Start is called before the first frame update
    void Start()
    {
        crearPanes();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo > 0)
        {
            tiempo -= Time.deltaTime;
            tiempoText.text = FormatearTiempo(tiempo);
        }
        else
        {
            tiempoText.text = "Fin del tiempo";
            //Adicion de Alex C
            if (puntos > 15)
            {
                SceneManager.LoadScene(scene.volver);
            }
            else
            {
                SceneManager.LoadScene("SaraMinijuego");
            }
        }

    }

    string FormatearTiempo(float tiempo){

        //Formateo minutos y segundos a dos dígitos
        string minutos = Mathf.Floor(tiempo / 60).ToString("0");
        string segundos = Mathf.Floor(tiempo % 60).ToString("00");
    
        //Devuelvo el string formateado con : como separador
        return "Tiempo: " + minutos + ":" + segundos;
  
    }

    void crearPanes(){
        GameObject Aux;
        for ( int i= 0; i<5; i++)
        {
            switch ( (int)Random.Range(1,4))
            {
                case 1: 
                Aux=Instantiate(Pan1,new Vector3((-1.8f-0.3f*i)*-1.6f-4f, -1.8f-0.3f*i, Pan1.transform.position.z),Quaternion.identity);
                panes[i] = Aux;
                Aux.GetComponent<SpriteRenderer>().sortingOrder = 10+i;
                break;

                case 2: 
                Aux=Instantiate(Pan2,new Vector3((-1.8f-0.3f*i)*-1.6f-4f, -1.8f-0.3f*i, Pan2.transform.position.z),Quaternion.identity);
                panes[i] = Aux;
                Aux.GetComponent<SpriteRenderer>().sortingOrder = 10+i;
                break;

                case 3: 
                Aux=Instantiate(Pan3,new Vector3((-1.8f-0.3f*i)*-1.6f-4f, -1.8f-0.3f*i, Pan3.transform.position.z),Quaternion.identity);
                panes[i] = Aux;
                Aux.GetComponent<SpriteRenderer>().sortingOrder = 10+i;
                break;
            }
        }
    }

    public void borrarPanes() {
        bool punto = true;
        for (int i = 0; i < 5; i++) {
            GameObject pan = panes[i];
            panes[i] = null;
            if (!pan.GetComponent<PanController>().bandejaCorrecta) {
                punto =false;
            }
            Destroy(pan);
        }
        if (punto) {
            puntos++;
            puntosText.text = "Puntos: " + puntos;
        }
        crearPanes();
    }
}
