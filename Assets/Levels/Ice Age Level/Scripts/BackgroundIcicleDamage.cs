using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIcicleDamage : MonoBehaviour
{
    [SerializeField] float damage = 10.0f;

    private void OnTriggerEnter(Collider collision)
    {
        float Health = collision.gameObject.GetComponent<DinoScript>().Health;

        Health = Health - damage;

        
    }
}
