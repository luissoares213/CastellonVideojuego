using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopoArbol1 : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite niño;
    [SerializeField] private Sprite niñoHit;
    [SerializeField] private Sprite niña;
    [SerializeField] private Sprite niñaHit;

    [Header("GameManager")]
    [SerializeField] private GameManager gameManager;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition;

    // How long it takes to show a mole.
    private float showDuration = 0.5f;
    private float duration = 1f;

    private bool hittable = true;

    public enum ChildType { Niño, Niña, Impostor};
    private ChildType childType;
    private float niñaRate = 0.5f;
    private int niñoIndex = 0;


    private BoxCollider2D boxCollider2D;
    private Vector2 boxOffset;
    private Vector2 boxSize;
    private Vector2 boxOffsetHidden;
    private Vector2 boxSizeHidden;

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        // Make sure we start at the start.
        transform.localPosition = start;

        // Show the mole.
        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);

            boxCollider2D.offset = Vector2.Lerp(boxOffsetHidden, boxOffset, elapsed / showDuration);

            boxCollider2D.size = Vector2.Lerp(boxSizeHidden, boxSize, elapsed / showDuration);

            // Update at max framerate.
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Make sure we're exactly at the end.
        transform.localPosition = end;
        boxCollider2D.offset = boxOffset;
        boxCollider2D.size = boxSize;

        // Wait for duration to pass.
        yield return new WaitForSeconds(duration);

        // Hide the mole.
        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            boxCollider2D.offset = Vector2.Lerp(boxOffset, boxOffsetHidden, elapsed / showDuration);

            boxCollider2D.size = Vector2.Lerp(boxSize, boxSizeHidden, elapsed / showDuration);


            // Update at max framerate.
            elapsed += Time.deltaTime;
            yield return null;
        }
        // Make sure we're exactly back at the start position.
        transform.localPosition = start;
        boxCollider2D.offset = boxOffsetHidden;
        boxCollider2D.size = boxSizeHidden;
        if (hittable)
        {

            hittable = false;
            gameManager.Missed(niñoIndex, childType != ChildType.Impostor);
        }
    }


    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);

        if(hittable != true)
        {
            Hide();
        }
        
    }

    public void Hide()
    {
        transform.localPosition = endPosition;
        boxCollider2D.offset = boxOffsetHidden;
        boxCollider2D.size = boxSizeHidden;
    }


    void CreateNext()
    {
        float random = Random.Range(0f, 1f);

        if(random < niñaRate)
        {
            childType = ChildType.Niña;
            spriteRenderer.sprite = niña;
        }
        else
        {
            childType = ChildType.Niño;
            spriteRenderer.sprite = niño;
        }

        hittable = true;
    }

    private void OnMouseDown()
    {
        if (hittable)
        {
            switch (childType)
            {
                case ChildType.Niña:
                    spriteRenderer.sprite = niñaHit;
                    gameManager.AddScore(niñoIndex);
                    // Stop the animation
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());

                    hittable=false;

                    break;
                case ChildType.Niño:
                    spriteRenderer.sprite = niñoHit;
                    gameManager.AddScore(niñoIndex);
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());

                    hittable = false;

                    break;
                /*case ChildType.Impostor:
                    spriteRenderer.sprite = moleHit;

                    StopAllCoroutines();
                    StartCoroutine(QuickHide());

                    hittable = false;

                    break;*/
                default: break;


            }
        }
    }

    private void SetLevel(int level)
    {
        niñaRate = Mathf.Min(level * 0.03f, 1f);

        float durationMin = Mathf.Clamp(1 - level * 0.1f, 0.01f, 1f);
        float durationMax = Mathf.Clamp(2 - level * 0.1f, 0.01f, 2f);
        duration = Random.Range(durationMin, durationMax);
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();


        // Work out collider values.
        boxOffset = boxCollider2D.offset;
        boxSize = boxCollider2D.size;
        boxOffsetHidden = new Vector2(boxOffset.x, -startPosition.y / 2f);
        boxSizeHidden = new Vector2(boxSize.x, 0f);
    }
    // Start is called before the first frame update
    public void Activate()
    {
        //SetLevel(level);
        CreateNext();
        StartCoroutine(ShowHide(startPosition, endPosition));
    }

    public void SetIndex(int index)
    {
        niñoIndex = index;
    }

    public void StopGame()
    {
        hittable = false;
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
