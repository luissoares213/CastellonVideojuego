
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErmitaDia : MonoBehaviour
{

    public Transform newCamPosition;
    public Transform newPeriodistaPos;
    public GameObject periodista;
    public SceneInfo sceneInfo;

    public void MoveCameraXY()
    {
        if (newCamPosition != null)
        {
            Vector3 newCamPositionXY = new Vector3(newCamPosition.position.x, newCamPosition.position.y, Camera.main.transform.position.z);
            //Camera.main.transform.position = newCamPositionXY;
            sceneInfo.cameraPos = newCamPositionXY;
            //Mover a la periodista
            periodista.GetComponent<MoveA>().dest= newPeriodistaPos.position;
            periodista.transform.position =newPeriodistaPos.position;

        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
