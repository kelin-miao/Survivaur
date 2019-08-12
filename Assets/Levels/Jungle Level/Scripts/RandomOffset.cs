using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOffset : MonoBehaviour
{
    [SerializeField] float offsetMax = 1.0f;
    [SerializeField] float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = Random.Range(-offsetMax, offsetMax);
        gameObject.transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
