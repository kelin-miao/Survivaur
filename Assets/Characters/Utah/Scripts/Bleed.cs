using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    float bleedTime = 7.0f;
    float initialDamage = 15.0f;
    GameObject OtherDino;
    bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        facingRight = gameObject.GetComponentInParent<DinoScript>().facingRight;
    }
    private void OnTriggerEnter2D(Collider2D SpecColl)
    {
        if (SpecColl.gameObject.tag == "Player")
        {
            print("SpecColl");
            SpecColl.gameObject.GetComponent<DinoScript>().Bleeding = true;
            SpecColl.gameObject.GetComponent<DinoScript>().Health = SpecColl.gameObject.GetComponent<DinoScript>().Health - (initialDamage * gameObject.GetComponentInParent<DinoScript>().Adrenaline);
            SpecColl.gameObject.GetComponent<DinoScript>().Invoke("StopBleed", bleedTime);
            if (facingRight)
            {
                SpecColl.gameObject.SendMessage("KnockbackRight");
            }
            if (!facingRight)
            {
                SpecColl.gameObject.SendMessage("KnockbackLeft");
            }
        }
    }
}
