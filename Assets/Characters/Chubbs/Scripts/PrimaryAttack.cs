using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    public GameObject parent;
    bool herbivore;
    public bool facingRight;
    public float attackDam = 20;
    float attackDamage;
    public float nutrition = 20;
    // Start is called before the first frame update
    void Start()
    {
        herbivore = gameObject.GetComponentInParent<DinoScript>().Herbivore;
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
            if(!attackColl.gameObject.GetComponent<DinoScript>().blocking)
            {
                //print(attackColl.gameObject.ToString());
                //Lower enemy health
                attackColl.gameObject.GetComponent<DinoScript>().Health = attackColl.gameObject.GetComponent<DinoScript>().Health - (attackDamage * gameObject.GetComponentInParent<DinoScript>().Adrenaline);
                //Knockback enemy depending on which way attacker is facing
                if (facingRight)
                {
                    attackColl.gameObject.SendMessage("KnockbackRight");
                }
                if (!facingRight)
                {
                    attackColl.gameObject.SendMessage("KnockbackLeft");
                }
                //Raise enemy adrenaline
                if (attackColl.gameObject.GetComponent<DinoScript>().Adrenaline + (attackDamage / 100) < attackColl.gameObject.GetComponent<DinoScript>().MaxAdrenaline)
                {
                    attackColl.gameObject.GetComponent<DinoScript>().Adrenaline = attackColl.gameObject.GetComponent<DinoScript>().Adrenaline + (attackDamage / 100);
                }
                else
                {
                    attackColl.gameObject.GetComponent<DinoScript>().Adrenaline = attackColl.gameObject.GetComponent<DinoScript>().MaxAdrenaline;
                }
                //raise attacker adrenaline
                if (gameObject.GetComponentInParent<DinoScript>().Adrenaline + (attackDamage / 80) < gameObject.GetComponentInParent<DinoScript>().MaxAdrenaline)
                {
                    gameObject.GetComponentInParent<DinoScript>().Adrenaline = gameObject.GetComponentInParent<DinoScript>().Adrenaline + (attackDamage / 80); //probably swap this 80 and the 100 above for herbivores
                }
                else
                {
                    gameObject.GetComponentInParent<DinoScript>().Adrenaline = gameObject.GetComponentInParent<DinoScript>().MaxAdrenaline;
                }
            }
            if (attackColl.gameObject.GetComponent<DinoScript>().blocking)
            {
                //print(attackColl.gameObject.ToString());
                //Lower enemy health
                attackColl.gameObject.GetComponent<DinoScript>().Health = attackColl.gameObject.GetComponent<DinoScript>().Health - ((attackDamage * gameObject.GetComponentInParent<DinoScript>().Adrenaline) * 0.25f);
                //Lower enemy block
                attackColl.gameObject.GetComponent<DinoScript>().block = (attackColl.gameObject.GetComponent<DinoScript>().block - (attackColl.gameObject.GetComponent<DinoScript>().block / 10));
                //Raise enemy adrenaline
                if (attackColl.gameObject.GetComponent<DinoScript>().Adrenaline + (attackDamage / 50) < attackColl.gameObject.GetComponent<DinoScript>().MaxAdrenaline)
                {
                    attackColl.gameObject.GetComponent<DinoScript>().Adrenaline = attackColl.gameObject.GetComponent<DinoScript>().Adrenaline + (attackDamage / 50);
                }
                else
                {
                    attackColl.gameObject.GetComponent<DinoScript>().Adrenaline = attackColl.gameObject.GetComponent<DinoScript>().MaxAdrenaline;
                }
                //raise attacker adrenaline
                if (gameObject.GetComponentInParent<DinoScript>().Adrenaline + (attackDamage / 125) < gameObject.GetComponentInParent<DinoScript>().MaxAdrenaline)
                {
                    gameObject.GetComponentInParent<DinoScript>().Adrenaline = gameObject.GetComponentInParent<DinoScript>().Adrenaline + (attackDamage / 125); //probably swap this 80 and the 100 above for herbivores
                }
                else
                {
                    gameObject.GetComponentInParent<DinoScript>().Adrenaline = gameObject.GetComponentInParent<DinoScript>().MaxAdrenaline;
                }
            }
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        //Carnivore Feeding (!DISABLE FOR HERBIVORES!)
        if (attackColl.gameObject.tag == "Corpse" && !herbivore)
        {
            if(gameObject.GetComponentInParent<DinoScript>().Hunger + nutrition < gameObject.GetComponentInParent<DinoScript>().MaxHunger)
            {
                gameObject.GetComponentInParent<DinoScript>().Hunger = gameObject.GetComponentInParent<DinoScript>().Hunger + nutrition;
            }
            else
            {
                gameObject.GetComponentInParent<DinoScript>().Hunger = gameObject.GetComponentInParent<DinoScript>().MaxHunger;
            }
            attackColl.gameObject.GetComponent<DinoScript>().corpseNutrition = attackColl.gameObject.GetComponent<DinoScript>().corpseNutrition - nutrition;
        }
        if (attackColl.gameObject.tag == "HerbBush" && herbivore)
        {
            if (gameObject.GetComponentInParent<DinoScript>().Hunger + nutrition < gameObject.GetComponentInParent<DinoScript>().MaxHunger)
            {
                gameObject.GetComponentInParent<DinoScript>().Hunger = gameObject.GetComponentInParent<DinoScript>().Hunger + nutrition;
            }
            else
            {
                gameObject.GetComponentInParent<DinoScript>().Hunger = gameObject.GetComponentInParent<DinoScript>().MaxHunger;
            }
            attackColl.gameObject.GetComponent<HerbScript>().HerbNutrition = attackColl.gameObject.GetComponent<HerbScript>().HerbNutrition - nutrition;
        }
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
