using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        startColor = sr.color;
    }
    //Para que el sprite cambie de color cuando el mouse se ponga encima.
    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }
    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
