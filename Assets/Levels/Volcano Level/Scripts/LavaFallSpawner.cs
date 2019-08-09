using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFallSpawner : MonoBehaviour
{
    [SerializeField] private float spawnDistance = 12.0f;
    [SerializeField] private float timeTillRespawn = 0.5f;
    [SerializeField] private GameObject lavaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        RecursiveSpawn();
    }

    void RecursiveSpawn()
    {
        float RandDistance = Random.Range(0, spawnDistance);
        Instantiate(lavaPrefab,new Vector3(transform.position.x + RandDistance,transform.position.y,transform.position.z), transform.localRotation);

        Invoke("RecursiveSpawn", timeTillRespawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
