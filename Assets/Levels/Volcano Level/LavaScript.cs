using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    [SerializeField] float lavaDamage = 50.0f;
    [SerializeField] float lavaKnockBackForce = 20.0f;

    [SerializeField] float riseAndFallMax = 6.0f;

    [SerializeField] float timeScale = 0.5f;

    Vector2 StartPos;


    // Start is called before the first frame update
    void Start()
    {
        StartPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RiseAndFall();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<DinoScript>().Health = coll.gameObject.GetComponent<DinoScript>().Health - lavaDamage;
            coll.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,lavaKnockBackForce);
        }
    }

    private void RiseAndFall()
    {
        gameObject.transform.position = new Vector3(0 + StartPos.x, riseAndFallMax * Mathf.Sin(Time.time * timeScale) + StartPos.y);
    }
}
