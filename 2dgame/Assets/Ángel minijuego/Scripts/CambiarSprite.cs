using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarSprite : MonoBehaviour
{
    public Sprite[] sprites; // Asigna tus sprites desde el Inspector

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sprites.Length > 0)
        {
            CambiarSpriteAleatorioPrefab();
        }
        else
        {
            Debug.LogError("Asegúrate de asignar sprites al array en el inspector.");
        }
    }

    void CambiarSpriteAleatorioPrefab()
    {
        int indiceAleatorio = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[indiceAleatorio];
    }
}
