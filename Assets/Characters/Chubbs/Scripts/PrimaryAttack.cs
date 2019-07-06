using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    public GameObject parent;
    public bool facingRight;
    public float attackDam = 20;
    float attackDamage;
    public float nutrition = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        facingRight = gameObject.GetComponentInParent<DinoScript>().facingRight;
        attackDamage = (attackDam * gameObject.GetComponentInParent<DinoScript>().Adrenaline);
    }

    //On collider tagged "Player", call "TakeDamage" Method with damage specified by "attackDamage" Variable
    void OnTriggerEnter2D(Collider2D attackColl)
    {
        GameObject OtherDino = attackColl.gameObject;
        if (attackColl.gameObject.tag == "Player")
        {
            print(attackColl.gameObject.ToString());
            attackColl.gameObject.GetComponent<DinoScript>().Health = attackColl.gameObject.GetComponent<DinoScript>().Health - (attackDamage * attackColl.gameObject.GetComponent<DinoScript>().Adrenaline);
            if (facingRight)
            {
                attackColl.gameObject.SendMessage("KnockbackRight");
            }
            if (!facingRight)
            {
                attackColl.gameObject.SendMessage("KnockbackLeft");
            }
            if(attackColl.gameObject.GetComponent<DinoScript>().Adrenaline + (attackDamage / 100) < attackColl.gameObject.GetComponent<DinoScript>().MaxAdrenaline)
            {
                attackColl.gameObject.GetComponent<DinoScript>().Adrenaline = attackColl.gameObject.GetComponent<DinoScript>().Adrenaline + (attackDamage / 100);
            }
            else
            {
                attackColl.gameObject.GetComponent<DinoScript>().Adrenaline = attackColl.gameObject.GetComponent<DinoScript>().MaxAdrenaline;
            }
            if (gameObject.GetComponentInParent<DinoScript>().Adrenaline + (attackDamage / 80) < gameObject.GetComponentInParent<DinoScript>().MaxAdrenaline)
            {
                gameObject.GetComponentInParent<DinoScript>().Adrenaline = gameObject.GetComponentInParent<DinoScript>().Adrenaline + (attackDamage / 80); //probably swap this 80 and the 100 above for herbivores
            }
            else
            {
                gameObject.GetComponentInParent<DinoScript>().Adrenaline = gameObject.GetComponentInParent<DinoScript>().MaxAdrenaline;
            }
            
        }
        //Carnivore Feeding (!DISABLE FOR HERBIVORES!)
        if (attackColl.gameObject.tag == "Corpse")
        {
            if(gameObject.GetComponentInParent<DinoScript>().Hunger + nutrition < 100)
            {
                gameObject.GetComponentInParent<DinoScript>().Hunger = gameObject.GetComponentInParent<DinoScript>().Hunger + nutrition;
            }
            else
            {
                gameObject.GetComponentInParent<DinoScript>().Hunger = 100;
            }
            attackColl.gameObject.GetComponent<DinoScript>().corpseNutrition = attackColl.gameObject.GetComponent<DinoScript>().corpseNutrition - nutrition;
        }
    }
}
