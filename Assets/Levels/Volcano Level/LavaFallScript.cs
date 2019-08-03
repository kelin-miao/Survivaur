using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFallScript : MonoBehaviour
{
    [SerializeField] private float lavaFallDamage = 20.0f;
    [SerializeField] private float lavaKnockBackForce = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<DinoScript>().Health = coll.gameObject.GetComponent<DinoScript>().Health - lavaFallDamage;
            coll.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, lavaKnockBackForce);
        }

        Destroy(gameObject,0.0f);
    }
}
