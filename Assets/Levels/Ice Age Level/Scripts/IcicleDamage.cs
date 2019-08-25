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
            if(collision.gameObject.GetComponent<DinoScript>().blocking == false)
            {
                collision.gameObject.GetComponent<DinoScript>().Health -= 5.0f;
            }
            else
            {
                collision.gameObject.GetComponent<DinoScript>().block -= 7.0f;
            }
        }


        Destroy(gameObject);

    }

    //private void OnCollisionEnter(Collision collision)
    //{


    //}
}
