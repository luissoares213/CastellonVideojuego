using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackM : MonoBehaviour
{
    [SerializeField] private string regresar;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        SceneManager.LoadScene(regresar);
    }
}
