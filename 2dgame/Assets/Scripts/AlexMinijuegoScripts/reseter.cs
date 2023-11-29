using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reseter : MonoBehaviour
{
    public List<BlockControler> blocks = new List<BlockControler>();
    public void Res() //Llamar a la función de resetear la posicion para cada bloque
    {
        foreach (BlockControler obj in blocks)
        {
            obj.gameObject.GetComponent<BlockControler>().ResetearPos();
        }
    }
}
