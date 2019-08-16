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

        float depthColour = 1.0f / Mathf.Abs(depth);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = new Color(depthColour, depthColour, depthColour, 1.0f);

        if (depth > 0)
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x / Mathf.Abs(depth), transform.localScale.y, transform.localScale.z);
        }

        if (depth < 0)
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x * Mathf.Abs(depth/2.0f) + 1.0f, transform.localScale.y, transform.localScale.z);
        }


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
