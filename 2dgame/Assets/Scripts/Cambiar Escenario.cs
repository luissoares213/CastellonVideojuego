
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErmitaDia : MonoBehaviour
{

    public Transform newCamPosition;

    public void MoveCameraXY()
    {
        if (newCamPosition != null)
        {
            Vector3 newCamPositionXY = new Vector3(newCamPosition.position.x, newCamPosition.position.y, Camera.main.transform.position.z);
            Camera.main.transform.position = newCamPositionXY;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
