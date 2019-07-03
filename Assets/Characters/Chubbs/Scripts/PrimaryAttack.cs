using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    public GameObject parent;
    public bool facingRight;
    public float attackDamage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        facingRight = gameObject.GetComponentInParent<DinoScript>().facingRight;
    }

    //On collider tagged "Player", call "TakeDamage" Method with damage specified by "attackDamage" Variable
    void OnTriggerEnter2D(Collider2D attackColl)
    {
        GameObject OtherDino = attackColl.gameObject;
        if (attackColl.gameObject.tag != this.tag)
        {
            print(attackColl.gameObject.ToString());
            attackColl.gameObject.GetComponent<DinoScript>().Health = attackColl.gameObject.GetComponent<DinoScript>().Health - attackDamage;
            if (facingRight)
            {
                attackColl.gameObject.SendMessage("KnockbackRight");
            }
            if (!facingRight)
            {
                attackColl.gameObject.SendMessage("KnockbackLeft");
            }
        }
    }
}
