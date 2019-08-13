using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTree : MonoBehaviour
{
    [Range(0,20)]
    [SerializeField] int numberTrees;

    [SerializeField] GameObject treePrefab;
    [SerializeField] float treeDistance = 3.84f;
    [SerializeField] float offset = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        //Spawn Positions = -2.88, -2.24, -1.6, -1.26, -0.96, -0.32, 0.32, 0.96, 1.6, 2.24, 2.88
        // 0.64 units apart

        //set values
        int[] valueStore = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19};

        //Shuffle
        for (int i = valueStore.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = valueStore[i];
            valueStore[i] = valueStore[j];
            valueStore[j] = temp;
        }
        
        for (int i = 0; i < numberTrees; i++)
        {
            InstantiateTree((treeDistance  * valueStore[i]) - Random.Range(-treeDistance/2.0f, treeDistance/2.0f) - offset);
        }
    }

    void InstantiateTree(float xPos)
    {
        Instantiate(treePrefab, new Vector3 (xPos, transform.position.y, transform.position.z), transform.rotation, gameObject.transform);

    }
}
