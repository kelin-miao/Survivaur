using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeout : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    float startTime;
    bool started = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            float alphaColour = spriteRenderer.color.a;
            float t = (Time.time - startTime) / 2.5f;
            alphaColour = Mathf.SmoothStep(alphaColour, 1.0f, t);
            spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, alphaColour);
        }
    }
}
