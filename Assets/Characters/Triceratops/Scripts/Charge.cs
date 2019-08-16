using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    float stunTime = 10.0f;
    float chargeForceX = 6;
    float chargeForceY = 6;
    float chargeDamage = 25;
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
            if(gameObject.GetComponentInParent<DinoScript>().facingRight)
            {
                SpecColl.gameObject.GetComponent<DinoScript>().rigbod.velocity = new Vector2(chargeForceX * 1.5f, chargeForceY * 1.5f);
            }
            else if(gameObject.GetComponentInParent<DinoScript>().facingRight == false)
            {
                SpecColl.gameObject.GetComponent<DinoScript>().rigbod.velocity = new Vector2(-chargeForceX * 1.5f, chargeForceY * 1.5f);
            }
            //SpecColl.gameObject.GetComponent<DinoScript>().Stun();
            //SpecColl.gameObject.GetComponent<DinoScript>().Invoke("Reset", stunTime);
            //Damage Flash
            SpecColl.GetComponent<DinoScript>().Invoke("DamageColorChange", 0.0f);
            SpecColl.GetComponent<DinoScript>().damageLoop = true;
            SpecColl.GetComponent<DinoScript>().Invoke("DamageLoopBreak", 0.3f);
            SpecColl.gameObject.GetComponent<DinoScript>().Health = SpecColl.gameObject.GetComponent<DinoScript>().Health - chargeDamage;
        }
        if (SpecColl.gameObject.tag == "EnvironmentEntity")
        {
            SpecColl.gameObject.GetComponent<IceWall>().wallHP = SpecColl.gameObject.GetComponent<IceWall>().wallHP - 160;
        }
    }
}
