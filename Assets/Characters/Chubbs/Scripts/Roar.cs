using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roar : MonoBehaviour
{
    float stunTime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D SpecColl)
    {
        GameObject OtherDino = SpecColl.gameObject;
        if (SpecColl.gameObject.tag == "Player")
        {
            print("SpecColl");
            SpecColl.gameObject.GetComponent<DinoScript>().Stun();
            SpecColl.gameObject.GetComponent<DinoScript>().Invoke("Reset", stunTime);
        }
    }
}
