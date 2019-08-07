using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoScript : MonoBehaviour
{
    //General
    public int playerNumber;
    public bool isHerbivore;
    public int specAttack;
    public bool Bleeding;
    public bool blocking;

    //Audio
    public AudioClip biteSound;
    public AudioClip specialAttackSound;
    public AudioClip walkingSound;
    public AudioClip jumpSound;
    public AudioClip DeathSound;
    public ParticleSystem DeathEffect;

    //Stats
    //maxvalues
    public float MaxHealth = 300;
    public float MaxHunger = 100f;
    public float MaxAdrenaline = 2.0f;
    public float MaxBlock = 70.0f;
    //Health Value
    public float Health;
    //Alive bool
    bool alive = true;
    //Health Drain Multiplier
    public float healthDrainMult = 2;
    //Hunger Value
    public float Hunger;
    //Hunger Drain Multiplier
    public float hungerDrainMult = 3;
    //block resource
    public float block;
    //block drain
    float blockDrainMult = 7.0f;
    //Number under which block breaks
    float blockthreshold = 15.0f;
    //Adrenaline
    [Range(1, 2)]
    public float Adrenaline;
    //Adrenaline requirement for special attack
    public float AdRequirement;
    //Adrenline Drain Multiplier
    public float adrenalinedrainMult = 0.55f;
    //Movement speed
    public float maxSpeed;
    float moveSpeed = 3;
    //Force of jumps
    public float jumpForce = 6;
    //How much the dino moves when hit
    float knockbackForceX = 2.0f;
    float knockbackForceY = 3.0f;
    //How long before the dino can attack again (ANIMATION LENGTH)
    float attack1Delay = 0.5f;
    //How long after special attack before dino can attack again (ANIM LENGTH)
    public float specattackDelay = 0.65f;
    //How much hunger can be restored by eating this dino's corpse
    public float corpseNutrition = 100;
    float MaxBubbleSizeX;
    float MaxBubbleSizeY;
    //Technical
    //Collider used for map navigation
    BoxCollider2D navCollider;

    //Check if dino is on ground
    bool grounded = false;
    //Check if dino is on wall
    bool walled = false;
    bool canWall = true;
    bool wallOnRight;
    //Dino's rigidbody
    public Rigidbody2D rigbod;
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
    //Bubble Shield
    GameObject bubbleShield;
    //Audio Source
    AudioSource audiosource;
    //Player Tag
    Text playerTag;
    GameObject tagObj;
    Sprite baseADRback;
    public Sprite SpecableADRback;


    void Awake()
    {
        if (playerNumber == 1)
        {
            facingRight = true;
        }
        if (playerNumber == 2)
        {
            facingRight = false;
            transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        Health = MaxHealth;
        Hunger = MaxHunger;
        moveSpeed = maxSpeed;
        Adrenaline = 1;
        Bleeding = false;
        blocking = false;
        block = MaxBlock;
        MaxBubbleSizeX = gameObject.transform.Find("Canvas").gameObject.transform.Find("Bubble").GetComponentInChildren<RectTransform>().localScale.x;
        MaxBubbleSizeY = gameObject.transform.Find("Canvas").gameObject.transform.Find("Bubble").GetComponentInChildren<RectTransform>().localScale.y;
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = walkingSound;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Get Player Tag
        baseADRback = gameObject.transform.Find("Canvas").gameObject.transform.Find("AdrenalineSlider").gameObject.transform.Find("Background").GetComponent<Image>().sprite;
        tagObj = gameObject.transform.Find("Canvas").gameObject.transform.Find("PlayerTag").gameObject;
        playerTag = gameObject.transform.Find("Canvas").gameObject.transform.Find("PlayerTag").GetComponentInChildren<Text>();
        playerTag.text = "Player " + playerNumber;
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

        HPslider.maxValue = MaxHealth;
        hungerSlider.maxValue = MaxHunger;
        adrenalineSlider.maxValue = MaxAdrenaline;

        bubbleShield = gameObject.transform.Find("Canvas").gameObject.transform.Find("Bubble").GetComponentInChildren<RectTransform>().gameObject;
        bubbleShield.SetActive(false);

    }


    //Jumping
    //Check if Dino has hit ground    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(alive)
        {
            //Standard Jumping
            if (coll.gameObject.tag == "Ground")
            {
                //Jump Script
                //print("Ground");
                grounded = true;
                animController.SetBool("Grounded", true);
                animController.Play("Idle");
                canattack = true;
            }
            //Wall jumping
            if (coll.gameObject.tag == "Wall")
            {
                walled = true;
                if (coll.transform.position.x > gameObject.transform.position.x)
                {
                    wallOnRight = true;
                }
                else
                {
                    wallOnRight = false;
                }
                //animController.SetBool("Grounded", true);
                //canattack = true;
            }
        }
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if(alive)
        {
            //if (coll.gameObject.tag == "Ground")
            //{
            //    transform.transform.Translate(Vector2.up * 0.0001f);
            //}
            if (coll.gameObject.tag == "Wall")
            {
                walled = false;
                transform.transform.Translate(Vector2.right * 0.0001f);
            }
        }
    }

    //Check if Dino has left ground
    void OnCollisionExit2D(Collision2D coll)
    {
        //Standard Jumping
        if (coll.gameObject.tag == "Ground")
        {
            //Jump Script
            //print("Unground");
            grounded = false;
            animController.SetBool("Grounded", false);
            //canattack = false;
        }
        //Wall jumping
        if (coll.gameObject.tag == "Wall")
        {
            //Jump Script
            //print("Unground");
            walled = false;
            //animController.SetBool("Grounded", false);
            //canattack = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (playerNumber == 1)
            {
                //Normal Jumping
                if (grounded && (Input.GetKeyDown(InputManager.IM.p1jump)) && canattack == true)
                {
                    rigbod.velocity = new Vector2(rigbod.velocity.x, jumpForce);
                    audiosource.Stop();
                }
                //Wall Jumping
                if (walled && (Input.GetKey(InputManager.IM.p1jump)) && canWall)
                {
                    if (wallOnRight && facingRight)
                    {
                        rigbod.velocity = new Vector2(-jumpForce, jumpForce);
                        canWall = false;
                        Invoke("WallJumpReset", 0.3f);
                    }
                    else if (!wallOnRight && !facingRight)
                    {
                        rigbod.velocity = new Vector2(jumpForce, jumpForce);
                        canWall = false;
                        Invoke("WallJumpReset", 0.3f);
                    }

                }
                if (Input.GetKeyDown(InputManager.IM.p1attack1) && canattack == true)
                {
                    attack();
                    canattack = false;
                }
                if (Input.GetKey(InputManager.IM.p1special) && canattack)
                {
                    SpecialAttack();
                }
                if (Input.GetKeyDown(InputManager.IM.p1block) && block >= blockthreshold)
                {
                    blocking = true;
                    bubbleShield.SetActive(true);
                    canattack = false;
                }
                if (Input.GetKeyUp(InputManager.IM.p1block))
                {
                    Reset();
                }
            }
            if (playerNumber == 2)
            {
                //Standard Jumping
                if (grounded && (Input.GetKeyDown(InputManager.IM.p2jump)) && canattack == true)
                {
                    rigbod.velocity = new Vector2(rigbod.velocity.x, jumpForce);
                    audiosource.Stop();
                }
                //Wall Jumping
                if (walled && (Input.GetKey(InputManager.IM.p2jump)) && canWall)
                {
                    if (wallOnRight && facingRight)
                    {
                        rigbod.velocity = new Vector2(-jumpForce, jumpForce);
                        canWall = false;
                        Invoke("WallJumpReset", 0.3f);
                    }
                    else if (!wallOnRight && !facingRight)
                    {
                        rigbod.velocity = new Vector2(jumpForce, jumpForce);
                        canWall = false;
                        Invoke("WallJumpReset", 0.3f);
                    }

                }
                if (Input.GetKeyDown(InputManager.IM.p2attack1) && canattack == true)
                {
                    attack();
                    canattack = false;
                }
                if (Input.GetKey(InputManager.IM.p2special) && canattack)
                {
                    SpecialAttack();
                }
                if (Input.GetKeyDown(InputManager.IM.p2block) && block >= blockthreshold)
                {
                    blocking = true;
                    bubbleShield.SetActive(true);
                    canattack = false;
                }
                if (Input.GetKeyUp(InputManager.IM.p2block))
                {
                    Reset();
                }
            }

            HealthRegen();
            HungerDrain();
            AdrenalineDrain();

            HPslider.value = Health;
            hungerSlider.value = Hunger;
            adrenalineSlider.value = Adrenaline;

            bubbleShield.GetComponent<RectTransform>().localScale = new Vector3(MaxBubbleSizeX * (block / 10), MaxBubbleSizeY * (block / 10));
            if (Bleeding)
            {
                Bleed();
            }
            if (Health < 0)
            {
                Die();
            }
            if (blocking)
            {
                block = block - (Time.deltaTime * blockDrainMult);
                if (block <= blockthreshold)
                {
                    block = (blockthreshold * 0.25f);

                    Reset();
                }
            }
            if (!blocking && block + (Time.deltaTime * blockDrainMult) < MaxBlock)
            {
                block = block + (Time.deltaTime * blockDrainMult);
            }
            //if(blocking && !grounded)
            //{
            //    blocking = false;
            //    bubbleShield.SetActive(false);
            //    canattack = false;
            //}
            if(Adrenaline >= AdRequirement)
            {
                gameObject.transform.Find("Canvas").gameObject.transform.Find("AdrenalineSlider").gameObject.transform.Find("Background").GetComponent<Image>().sprite = SpecableADRback;
            }
            else
            {
                gameObject.transform.Find("Canvas").gameObject.transform.Find("AdrenalineSlider").gameObject.transform.Find("Background").GetComponent<Image>().sprite = baseADRback;
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

    void WallJumpReset()
    {
        canWall = true;
    }

    //Handle Movement Input and call flipping
    void FixedUpdate()
    {
        if (alive)
        {

            if (playerNumber == 1)
            {
                if (Input.GetKey(InputManager.IM.p1right) && !blocking)
                {
                    //rigbod.velocity = new Vector2(moveSpeed, rigbod.velocity.y);
                    transform.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * Adrenaline);
                    animController.SetBool("Walking", true);
                    if (!audiosource.isPlaying && grounded && !blocking)
                    {
                        audiosource.Play();
                    }
                    if (!facingRight)
                    {
                        Flip();
                    }
                }
                else if (Input.GetKey(InputManager.IM.p1left) && !blocking)
                {
                    //rigbod.velocity = new Vector2(-moveSpeed, rigbod.velocity.y);
                    transform.transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime * Adrenaline);
                    animController.SetBool("Walking", true);
                    if (!audiosource.isPlaying && grounded && !blocking)
                    {
                        audiosource.Play();
                    }
                    if (facingRight)
                    {
                        Flip();
                    }
                }
                else
                {
                    animController.SetBool("Walking", false);
                    if (audiosource.isPlaying)
                    {
                        audiosource.Stop();
                    }
                }
            }


            if (playerNumber == 2)
            {
                if (Input.GetKey(InputManager.IM.p2right) && !blocking)
                {
                    //rigbod.velocity = new Vector2(moveSpeed, rigbod.velocity.y);
                    transform.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * Adrenaline);
                    animController.SetBool("Walking", true);
                    if (!audiosource.isPlaying && grounded && !blocking)
                    {
                        audiosource.Play();
                    }
                    if (!facingRight)
                    {
                        Flip();
                    }
                }
                else if (Input.GetKey(InputManager.IM.p2left) && !blocking)
                {
                    //rigbod.velocity = new Vector2(-moveSpeed, rigbod.velocity.y);
                    transform.transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime * Adrenaline);
                    animController.SetBool("Walking", true);
                    if (!audiosource.isPlaying && grounded && !blocking)
                    {
                        audiosource.Play();
                    }
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
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        tagObj.transform.localScale = new Vector3(tagObj.transform.localScale.x * -1, tagObj.transform.localScale.y, tagObj.transform.localScale.z);
    }
    //Reset Speed to norm, allow attacks, and disable damage colliders
    public void Reset()
    {
        gameObject.transform.Find("PrimaryAttackColl").GetComponent<CircleCollider2D>().enabled = false;
        gameObject.transform.Find("SpecialAttackColl").GetComponent<PolygonCollider2D>().enabled = false;
        animController.SetBool("Attacking", false);
        moveSpeed = maxSpeed;
        canattack = true;
        blocking = false;
        transform.transform.Translate(Vector2.right * 0.0001f);
        bubbleShield.SetActive(false);
    }
    //Bleed
    void Bleed()
    {
        if(Hunger <= 0)
        {
            Health -= (Time.deltaTime * healthDrainMult);
        }
        else
        {
            Health -= (Time.deltaTime * healthDrainMult * 2);
        }
    }
    public void StopBleed()
    {
        Bleeding = false;
    }
    //Enable attack Trigger and disable movement during attack
    void attack()
    {
        if (alive)
        {
            animController.SetBool("Attacking", true);
            transform.transform.Translate(Vector2.right * 0.0001f);
            //moveSpeed = 0;
            //animController.Play("Bite");
            AudioSource.PlayClipAtPoint(biteSound, transform.position, 2);
            gameObject.transform.Find("PrimaryAttackColl").GetComponent<CircleCollider2D>().enabled = true;
            Invoke("Reset", attack1Delay);
        }
    }
    void SpecialAttack()
    {
        //Roar
        if (alive && Adrenaline > AdRequirement && specAttack == 1)
        {
            moveSpeed = 0;
            animController.Play("Roar");
            AudioSource.PlayClipAtPoint(specialAttackSound, transform.position);
            gameObject.transform.Find("SpecialAttackColl").GetComponent<PolygonCollider2D>().enabled = true;
            Adrenaline = 1;
            Invoke("Reset", specattackDelay);
        }
        //Charge
        if (alive && Adrenaline > AdRequirement && specAttack == 2)
        {
            float chargeSpeed = 12;
            moveSpeed = 0;
            animController.Play("ChargeStart");
            if (facingRight)
            {
                transform.transform.Translate(Vector2.right * chargeSpeed * Time.deltaTime * Adrenaline);
            }
            else if (!facingRight)
            {
                transform.transform.Translate(Vector2.right * -chargeSpeed * Time.deltaTime * Adrenaline);
            }
            gameObject.transform.Find("SpecialAttackColl").GetComponent<PolygonCollider2D>().enabled = true;
            AudioSource.PlayClipAtPoint(specialAttackSound, transform.position);
            Adrenaline = Adrenaline - 0.01f;
            Invoke("Reset", specattackDelay);
        }
        //Bleed
        if (alive && Adrenaline > AdRequirement && specAttack == 3)
        {
            moveSpeed = 0;
            animController.Play("BleedCut");
            gameObject.transform.Find("SpecialAttackColl").GetComponent<PolygonCollider2D>().enabled = true;
            AudioSource.PlayClipAtPoint(specialAttackSound, transform.position);
            Adrenaline -= 0.4f;
            Invoke("Reset", specattackDelay);
        }
        //Tail Whip
        if (alive && Adrenaline > AdRequirement && specAttack == 4)
        {
            moveSpeed = 0;
            animController.Play("TailWhip");
            gameObject.transform.Find("SpecialAttackColl").GetComponent<PolygonCollider2D>().enabled = true;
            AudioSource.PlayClipAtPoint(specialAttackSound, transform.position);
            Adrenaline = 1;
            Invoke("Reset", specattackDelay);
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

    void HealthRegen()
    {
        if(Hunger > 0 && (Health + (Time.deltaTime * healthDrainMult) < MaxHealth))
        {
            Health += Time.deltaTime * healthDrainMult;
        }

    }
    //Hunger and health drain over time
    void HungerDrain()
    {
        if (Hunger > 0)
        {
            Hunger -= Time.deltaTime * hungerDrainMult * Adrenaline;
        }
        else
        {
            Health -= Time.deltaTime * healthDrainMult;
        }
    }
    void Die()
    {
        alive = false;
        AudioSource.PlayClipAtPoint(DeathSound, transform.position, 2);
        HPslider.enabled = false;
        hungerSlider.enabled = false;
        animController.Play("Die");
        Instantiate(DeathEffect, transform.position, transform.rotation);
        this.tag = ("Corpse");
        gameObject.layer = 9;
        this.GetComponent<SpriteRenderer>().sortingLayerName = "Corpse";
        rigbod.constraints = RigidbodyConstraints2D.FreezePositionX;
        gameObject.transform.Find("Canvas").gameObject.transform.Find("HealthSlider").GetComponentInChildren<RectTransform>().gameObject.SetActive(false);
        gameObject.transform.Find("Canvas").gameObject.transform.Find("HungerSlider").GetComponentInChildren<RectTransform>().gameObject.SetActive(false);
        gameObject.transform.Find("Canvas").gameObject.transform.Find("AdrenalineSlider").GetComponentInChildren<RectTransform>().gameObject.SetActive(false);
        tagObj.SetActive(false);
        gameObject.transform.Find("Canvas").gameObject.transform.Find("Arrow").gameObject.SetActive(false);

    }
    void AdrenalineDrain()
    {
        if ((Adrenaline > 1) && (Hunger > 0))
        {
            Adrenaline -= Time.deltaTime * adrenalinedrainMult;
        }
        else if ((Adrenaline < 2) && (Hunger <= 0))
        {
            Adrenaline += Time.deltaTime * adrenalinedrainMult;
        }
    }
    public void Stun()
    {
        gameObject.transform.Find("PrimaryAttackColl").GetComponent<CircleCollider2D>().enabled = false;
        gameObject.transform.Find("SpecialAttackColl").GetComponent<PolygonCollider2D>().enabled = false;
        moveSpeed = 0;
        canattack = false;
    }
}