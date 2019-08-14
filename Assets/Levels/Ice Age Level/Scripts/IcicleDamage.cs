using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float Health = collision.gameObject.GetComponent<DinoScript>().Health;

            Health -= 10f;
        }


        Destroy(gameObject);

    }

    //private void OnCollisionEnter(Collision collision)
    //{


    //}
}
