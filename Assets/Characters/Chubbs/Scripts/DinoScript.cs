using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoScript : MonoBehaviour
{
//General
    public int playerNumber;
    public bool Herbivore;
    //Stats
    //maxvalues
public float MaxHealth = 300;
public float MaxHunger = 100f;
public float MaxAdrenaline = 2.0f;
//Health Value
public float Health;
    //Alive bool
    bool alive = true;
//Health Drain Multiplier
public float healthDrainMult = 2;
    //Hunger Value
    [Range(0, 100)]
    public float Hunger;
//Hunger Drain Multiplier
public float hungerDrainMult = 3;
//Adrenaline
[Range(1, 2)]
public float Adrenaline;
//Adrenline Drain Multiplier
float adrenalinedrainMult = 0.75f;
//Movement speed
public float moveSpeed = 3;
//Force of jumps
public float jumpForce = 6;
//How much the dino moves when hit
float knockbackForceX = 2.0f;
float knockbackForceY = 3.0f;
//How long before the dino can attack again (ANIMATION LENGTH)
float attack1Delay = 0.64f;
//Damage done by attack one
public float attackDamage = 20.0f;
public float corpseNutrition = 100;

//Technical
//Collider used for map navigation
BoxCollider2D navCollider;
//casual mention of attack collider
//CircleCollider2D attackCollider;

//Check if dino is on ground
bool grounded = false;
//Dino's rigidbody
Rigidbody2D rigbod;
//Facing left or right
public bool facingRight;
//able to attack
bool canattack = true;
//Health Slider
Slider HPslider;
//hunger Slider
Slider hungerSlider;
//Adrenaline Slider
Slider adrenalineSlider;
//Animator
Animator animController;

    void Awake()
    {
        if(playerNumber == 1)
        {
            facingRight = true;
        }
        if (playerNumber == 2)
        {
            facingRight = false;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        Health = MaxHealth;
        Hunger = MaxHunger;
        Adrenaline = 1;
    }


    // Start is called before the first frame update
    void Start()
{
    //Get Animation Controller for controlling animations from this script
    animController = this.GetComponent<Animator>();
    //Get Rigidbody for this Dino for manipulation from this script
    rigbod = GetComponent<Rigidbody2D>();
    //Get Movement collider
    navCollider = GetComponent<BoxCollider2D>();
    //Make HealthBar
    HPslider = gameObject.transform.Find("Canvas").gameObject.transform.Find("HealthSlider").GetComponentInChildren<Slider>();
    hungerSlider = gameObject.transform.Find("Canvas").gameObject.transform.Find("HungerSlider").GetComponentInChildren<Slider>();
    adrenalineSlider = gameObject.transform.Find("Canvas").gameObject.transform.Find("AdrenalineSlider").GetComponentInChildren<Slider>();
    }


//Jumping
//Check if Dino has hit ground    
void OnCollisionEnter2D(Collision2D coll)
{
    if (coll.gameObject.tag == "Ground")
    {
        //Jump Script
        print("Ground");
        grounded = true;
        animController.SetBool("Grounded", true);
        canattack = true;
    }
}

//Check if Dino has left ground
void OnCollisionExit2D(Collision2D coll)
{
    if (coll.gameObject.tag == "Ground")
    {
        //Jump Script
        print("Unground");
        grounded = false;
        animController.SetBool("Grounded", false);
        canattack = false;
    }
}


// Update is called once per frame
void Update()
{
        if (alive)
        {
            if (playerNumber == 1)
            {
                if (grounded && (Input.GetKey(InputManager.IM.p1jump)) && canattack == true)
                {
                    rigbod.velocity = new Vector2(rigbod.velocity.x, jumpForce);
                }
                if (Input.GetKey(InputManager.IM.p1attack1) && canattack == true)
                {
                    attack();
                    canattack = false;
                }
            }
            if (playerNumber == 2)
            {
                if (grounded && (Input.GetKey(InputManager.IM.p2jump)) && canattack == true)
                {
                    rigbod.velocity = new Vector2(rigbod.velocity.x, jumpForce);
                }
                if (Input.GetKey(InputManager.IM.p2attack1) && canattack == true)
                {
                    attack();
                    canattack = false;
                }
            }

            HPslider.value = Health;
            HungerDrain();
            hungerSlider.value = Hunger;
            adrenalineSlider.value = Adrenaline;
            AdrenalineDrain();
            if (Health <= 0)
            {
                Die();
            }
        }
        if (!alive)
        {
            if (corpseNutrition <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
//Handle Movement Input and call flipping
void FixedUpdate()
{
        if (alive)
        {

            if (playerNumber == 1)
            {
                if (Input.GetKey(InputManager.IM.p1left))
                {
                    //rigbod.velocity = new Vector2(moveSpeed, rigbod.velocity.y);
                    transform.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * Adrenaline);
                    animController.SetBool("Walking", true);
                    if (!facingRight)
                    {
                        Flip();
                    }
                }
                else if (Input.GetKey(InputManager.IM.p1right))
                {
                    //rigbod.velocity = new Vector2(-moveSpeed, rigbod.velocity.y);
                    transform.transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime * Adrenaline);
                    animController.SetBool("Walking", true);
                    if (facingRight)
                    {
                        Flip();
                    }
                }
                else
                {
                    animController.SetBool("Walking", false);
                }
            }


            if (playerNumber == 2)
            {
                if (Input.GetKey(InputManager.IM.p2left))
                {
                    //rigbod.velocity = new Vector2(moveSpeed, rigbod.velocity.y);
                    transform.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * Adrenaline);
                    animController.SetBool("Walking", true);
                    if (!facingRight)
                    {
                        Flip();
                    }
                }
                else if (Input.GetKey(InputManager.IM.p2right))
                {
                    //rigbod.velocity = new Vector2(-moveSpeed, rigbod.velocity.y);
                    transform.transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime * Adrenaline);
                    animController.SetBool("Walking", true);
                    if (facingRight)
                    {
                        Flip();
                    }
                }
                else
                {
                    animController.SetBool("Walking", false);
                }
            }
        }
}
//Rotate character on input
void Flip()
{
    facingRight = !facingRight;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
}
//Reset Speed to norm, allow attacks, and disable damage colliders
void Reset()
{
        gameObject.transform.Find("PrimaryAttackColl").GetComponent<CircleCollider2D>().enabled = false;
        moveSpeed = 3;
        canattack = true;
        transform.transform.Translate(Vector2.right * 0.0001f);
}
//Enable attack Trigger and disable movement during attack
void attack()
{
        if (alive)
        {
            moveSpeed = 0;
            animController.Play("Bite");
            gameObject.transform.Find("PrimaryAttackColl").GetComponent<CircleCollider2D>().enabled = true;
            //Make/Get attack Collider
            //attackCollider = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
            //attackCollider.offset = new Vector2(0.19f, -0.04f);
            //attackCollider.radius = 0.04f;
            //attackCollider.isTrigger = true;
            //this.tag = "attacking";
            Invoke("Reset", attack1Delay);
        }
}
//Get Knocked away from attacker
void KnockbackRight()
{
        rigbod.velocity = new Vector2(knockbackForceX * 1, knockbackForceY * 1);
    }
void KnockbackLeft()
{
        rigbod.velocity = new Vector2(-knockbackForceX * 1, knockbackForceY * 1);
    }
//Hunger and health drain over time
void HungerDrain()
{
    if (Hunger > 0)
    {
        Hunger = Hunger - (Time.deltaTime * hungerDrainMult);
    }
    else
    {
        Health = Health - (Time.deltaTime * healthDrainMult);
    }
}
    void Die()
    {
        alive = false;
        HPslider.enabled = false;
        hungerSlider.enabled = false;
        animController.Play("Die");
        this.tag = ("Corpse");
        gameObject.layer = 9;
        this.GetComponent<SpriteRenderer>().sortingLayerName = "Corpse";
        rigbod.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
    void AdrenalineDrain()
    {
        if (Adrenaline > 1)
        {
            Adrenaline = Adrenaline - ((Time.deltaTime * adrenalinedrainMult)/ 6);
        }
    }
}