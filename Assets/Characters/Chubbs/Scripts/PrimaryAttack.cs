using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    [SerializeField] private float attackDam = 20;
    [SerializeField] private float herbivoreNutrition = 25;
    [SerializeField] private float carnivoreNutrition = 75;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    //On collider tagged "Player", call "TakeDamage" Method with damage specified by "attackDamage" Variable
    void OnTriggerEnter2D(Collider2D attackColl)
    {
        DinoScript otherDino = attackColl.gameObject.GetComponent<DinoScript>();
        DinoScript myDino = gameObject.GetComponentInParent<DinoScript>();

        float attackDamage = attackDam * myDino.Adrenaline;

        if (attackColl.gameObject.tag == "Player")
        {
            //Not Blocking
            if(!otherDino.blocking)
            {
                if (myDino.facingRight)
                {
                    attackColl.gameObject.SendMessage("KnockbackRight");
                }
                else
                {
                    attackColl.gameObject.SendMessage("KnockbackLeft");
                }

                //Lower enemy health
                otherDino.Health -= attackDamage * myDino.Adrenaline;

                //Knockback enemy depending on which way attacker is facing


                //Raise enemy adrenaline
                otherDino.Adrenaline += Mathf.Clamp(attackDamage / 100, 0, otherDino.MaxAdrenaline - otherDino.Adrenaline);

                //raise attacker adrenaline
                myDino.Adrenaline += Mathf.Clamp(attackDamage / 80, 0, myDino.MaxAdrenaline - myDino.Adrenaline);
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                //Damage Flash
                otherDino.GetComponent<DinoScript>().Invoke("DamageColorChange", 0.0f);
                otherDino.GetComponent<DinoScript>().damageLoop = true;
                otherDino.GetComponent<DinoScript>().Invoke("DamageLoopBreak", 0.3f);
            }

            //Is Blocking
            if (otherDino.blocking)
            {
                //Lower enemy health
                otherDino.Health -= attackDamage * myDino.Adrenaline * 0.25f;

                //Lower enemy block
                otherDino.block -= (otherDino.block - (otherDino.block / 10));

                //Raise enemy adrenaline
                otherDino.Adrenaline += Mathf.Clamp(attackDamage / 50, 0, otherDino.MaxAdrenaline - otherDino.Adrenaline);

                //raise attacker adrenaline
                myDino.Adrenaline += Mathf.Clamp(attackDamage / 125, 0, myDino.MaxAdrenaline - myDino.Adrenaline);
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }
            
        }

        //Carnivore Feeding (!DISABLE FOR HERBIVORES!)
        if (attackColl.gameObject.tag == "Corpse" && !myDino.isHerbivore)
        {
            myDino.Hunger += Mathf.Clamp(carnivoreNutrition, 0, myDino.MaxHunger - myDino.Hunger);
            otherDino.corpseNutrition -= carnivoreNutrition;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        //Herbivore Feeding
        if (attackColl.gameObject.tag == "HerbBush" && myDino.isHerbivore)
        {
            myDino.Hunger += Mathf.Clamp(herbivoreNutrition, 0, myDino.MaxHunger - myDino.Hunger);
            attackColl.gameObject.GetComponent<HerbScript>().HerbNutrition -= herbivoreNutrition;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }

        //Ice Wall
        if(attackColl.gameObject.tag == "EnvironmentEntity")
        {
            attackColl.gameObject.GetComponent<IceWall>().wallHP = attackColl.gameObject.GetComponent<IceWall>().wallHP - attackDamage;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
