using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().flipX = Random.value > 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
