using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteColour : MonoBehaviour
{
    int depth;

    // Start is called before the first frame update
    void Start()
    {
        depth = GetComponentInParent<Parallax>().depth;

        float depthColour = Mathf.Clamp(1.0f - (depth * 0.1f), 0.0f, 1.0f);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = new Color(depthColour, depthColour, depthColour, 1.0f);

        //set sorting order
        if (depth > 0)
        {
            spriteRenderer.sortingOrder = -depth - 1;
        }

        if (depth < 0)
        {
            spriteRenderer.sortingOrder = -depth + 1;
        }
    }
}
