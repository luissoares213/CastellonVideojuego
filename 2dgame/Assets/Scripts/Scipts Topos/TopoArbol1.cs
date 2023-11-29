using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopoArbol1 : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite mole;
    [SerializeField] private Sprite moleHit;
    [SerializeField] private Sprite moleHardHat;
    [SerializeField] private Sprite moleHatHit;

    private SpriteRenderer spriteRenderer;

    private Vector2 startPosition = new Vector2(-2.3f, 0f);
    private Vector2 endPosition = new Vector2(-3.8f, 0f);

    // How long it takes to show a mole.
    private float showDuration = 0.5f;
    private float duration = 1f;

    private bool hittable = true;

    public enum ChildType { Niño, Niña, Impostor};
    private ChildType childType;
    private float girlRate = 0.5f;


    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        // Make sure we start at the start.
        transform.localPosition = start;

        // Show the mole.
        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);

            // Update at max framerate.
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Make sure we're exactly at the end.
        transform.localPosition = end;

        // Wait for duration to pass.
        yield return new WaitForSeconds(duration);

        // Hide the mole.
        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);


            // Update at max framerate.
            elapsed += Time.deltaTime;
            yield return null;
        }
        // Make sure we're exactly back at the start position.
        transform.localPosition = start;
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
    }


    void CreateNext()
    {
        float random = Random.Range(0f, 1f);

        if(random < girlRate)
        {
            childType = ChildType.Niña;
            spriteRenderer.sprite = moleHardHat;
        }
        else
        {
            childType = ChildType.Niño;
            spriteRenderer.sprite = mole;
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
                    spriteRenderer.sprite = moleHatHit;
                    // Stop the animation
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());

                    hittable=false;

                    break;
                case ChildType.Niño:
                    spriteRenderer.sprite = moleHit;

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


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateNext();
        StartCoroutine(ShowHide(startPosition, endPosition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
