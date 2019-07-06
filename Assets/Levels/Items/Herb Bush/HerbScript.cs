using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbScript : MonoBehaviour
{
    public float HerbNutrition = 150;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HerbNutrition <= 0)
        {
            Destroy(gameObject);
        }
    }
}
