using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Camera main;
    public int depth;

    [SerializeField] float displacement;

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (depth != 0)
        {
            displacement = main.transform.position.x * depth / 10.0f;
            gameObject.transform.position = new Vector3( displacement, gameObject.transform.position.y , gameObject.transform.position.z);
        }
    }
}
