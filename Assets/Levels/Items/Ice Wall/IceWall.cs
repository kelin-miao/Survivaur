using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour
{
    Animator wallController;
    [Range(0, 160)]
    public float wallHP = 160;
    bool wallbroken = false;
    // Start is called before the first frame update
    void Start()
    {
        wallController = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        wallController.SetFloat("WallHealth", wallHP);
        wallController.SetBool("Broken", wallbroken);
        if(wallHP <= 0 && !wallbroken)
        {
            wallbroken = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Invoke("WallRegen", 10.0f);
        }
    }
    void WallRegen()
    {
        wallController.Play("IceWallRegen");
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
        wallHP = 160;
        wallbroken = false;
    }
}
