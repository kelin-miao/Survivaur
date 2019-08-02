using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWhip : MonoBehaviour
{
    float whipForceX = 10;
    float whipForceY = 5;
    float whipDamage = 55;
    float stunTime = 8;
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
        if (SpecColl.gameObject.tag == "Player")
        {
            print("SpecColl");
            if (gameObject.GetComponentInParent<DinoScript>().facingRight)
            {
                SpecColl.gameObject.GetComponent<DinoScript>().rigbod.velocity = new Vector2(whipForceX * 1.0f, whipForceY * 1.0f);
            }
            else if (gameObject.GetComponentInParent<DinoScript>().facingRight == false)
            {
                SpecColl.gameObject.GetComponent<DinoScript>().rigbod.velocity = new Vector2(-whipForceX * 1.0f, whipForceY * 1.0f);
            }
            SpecColl.gameObject.GetComponent<DinoScript>().Stun();
            SpecColl.gameObject.GetComponent<DinoScript>().Invoke("Reset", stunTime);
            SpecColl.gameObject.GetComponent<DinoScript>().Health = SpecColl.gameObject.GetComponent<DinoScript>().Health - whipDamage;
        }
        if (SpecColl.gameObject.tag == "EnvironmentEntity")
        {
            SpecColl.gameObject.GetComponent<IceWall>().wallHP = SpecColl.gameObject.GetComponent<IceWall>().wallHP - 160;
        }
    }
}
