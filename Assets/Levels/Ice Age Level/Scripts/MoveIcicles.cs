using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIcicles : MonoBehaviour
{

  
    public GameObject iciclePrefab;
    [SerializeField] private float maxDistance = 5f;

   

    
    void Start()
    {
        SpawnIcicle();
        //StartCoroutine(StartIcicles());
    }

   // IEnumerator StartIcicles()
   // {
        
   //     yield return StartCoroutine(IcicleMove());
   //     yield return StartCoroutine(WaitForSeconds());
   //     yield return StartCoroutine(IcicleMove());
   //     yield return StartCoroutine(WaitForSeconds());
   //     yield return StartCoroutine(IcicleMove());
   //     yield return StartCoroutine(WaitForSeconds());
   //     yield return StartCoroutine(IcicleMove());
   //     yield return StartCoroutine(WaitForSeconds());
   //     yield return StartCoroutine(IcicleMove());
   //     yield return StartCoroutine(WaitForSeconds());
        
   // }

   //IEnumerator WaitForSeconds()
   // {
   //     yield return new WaitForSeconds(Random.Range(min:5f, max:15f));
        
   // }

   // IEnumerator IcicleMove()
   // {
        
   //     InstantiateIcicle();
   //     yield return 0;
   // }

    

 void SpawnIcicle()
    {
       InstantiateIcicle();
       Invoke("SpawnIcicle", Random.Range(0.1f, 0.2f));
    }

    void InstantiateIcicle()
    {
        GameObject newIcicle = Instantiate(iciclePrefab, new Vector3(transform.position.x + Random.Range(-maxDistance, maxDistance), transform.position.y, transform.position.z), transform.rotation, gameObject.transform);
        
    }
}
