using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteColour : MonoBehaviour
{
    int depth;

    // Start is called before the first frame update
    void Start()
    {
        Parallax parallax = GetComponentInParent<Parallax>();

        if (parallax != null)
        {
            depth = parallax.depth;
        }

        if (depth != 0)
        {
            float depthColour = 1.0f - (depth * 0.1f);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            spriteRenderer.color = new Color(depthColour, depthColour, depthColour, 1.0f);
            spriteRenderer.sortingOrder = -depth;
        }
    }
}
