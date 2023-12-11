using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Controler : MonoBehaviour
{
    [SerializeField] private SceneInfo sceneInfo;
    public List<MoveB> NPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (MoveB item in NPC)
        {
            if (item.actoActivo == sceneInfo.acto)
            {
                item.gameObject.SetActive(true);
            }
            else {
                item.gameObject.SetActive(false);
            }


        }
        
    }
}
