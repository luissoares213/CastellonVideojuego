using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopoColumpio : MonoBehaviour
{

    private Vector2 startPosition = new Vector2(1.099f, 0.236f);
    private Vector2 endPosition = new Vector2(0.359f, 0.236f);

    // How long it takes to show a mole.
    private float showDuration = 0.5f;
    private float duration = 1f;


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





    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowHide(startPosition, endPosition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
