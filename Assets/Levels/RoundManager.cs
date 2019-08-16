using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    //Player Stuff
    int player1Char;
    int player2Char;
    [Range(0, 3)]
    public int player1Lives = 3;
    [Range(0, 3)]
    public int player2Lives = 3;
    bool p1lost = false;
    bool p2lost = false;

    //public GameObject[] Characters;
    public Transform p1Spawn;
    public Transform p2Spawn;
    public GameObject player1;
    public GameObject player2;
    public GameObject Wintext;
    Animator EndText;
    public GameObject MeteorEnd;
    Animator MeteorFlash;
    public GameObject p1Eggs;
    public GameObject p2Eggs;
    Color NormalColor;
    Color DuplicateColor;



    //Player transform references
    public Transform dino1;
    public Transform dino2;

    //Camera Variables
    [SerializeField] private float cameraLerpAmount = 0.05f;

    [SerializeField] private float minCameraSize = 12.0f;
    [SerializeField] private float maxCameraSize = 24.0f;


    private Vector3 velocity = Vector3.zero;
    [SerializeField] public float smoothTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        NormalColor = new Color(255, 255, 255, 255);
        DuplicateColor = new Color(255, 200, 130, 255);
        player1Char = (MenuScript.MenuManager.player1Char - 1);
        player2Char = (MenuScript.MenuManager.player2Char - 1);
        //Get Win text animator
        EndText = Wintext.GetComponent<Animator>();
        //Get Meteor ending animator
        MeteorFlash = MeteorEnd.GetComponent<Animator>();
        //Players
        Time.timeScale = 1.0f;
        //Make player 1
        player1 = Instantiate(MenuScript.MenuManager.Characters[(MenuScript.MenuManager.player1Char - 1)], p1Spawn.position, transform.rotation);
        player1.GetComponent<DinoScript>().playerNumber = 1;
        //player1.tag = "Player 1";
        //Make player 2
        player2 = Instantiate(MenuScript.MenuManager.Characters[(MenuScript.MenuManager.player2Char - 1)], p2Spawn.position, transform.rotation);
        player2.GetComponent<DinoScript>().playerNumber = 2;
        //player2.tag = "Player 2";
        if (player1Char == player2Char)
        {
            player2.GetComponent<DinoScript>().DupeChar = true;
        }
        dino1 = player1.GetComponent<Transform>();
        dino2 = player2.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Handle Death and respawn
        if (player1.GetComponent<DinoScript>().Health < 0)
        {
            Player1Death();
        }

        if (player2.GetComponent<DinoScript>().Health < 0)
        {
            Player2Death();
        }

        if (player1Lives <= 0 && p1lost == false && !p2lost)
        {
            Player2Victory();
        }
        if (player2Lives <= 0 && p2lost == false && !p1lost)
        {
            Player1Victory();
        }
        p1Eggs.GetComponent<Animator>().SetInteger("lives", player1Lives);
        p2Eggs.GetComponent<Animator>().SetInteger("lives", player2Lives);
        if (player1Lives <= 0 && player2Lives <= 0)
        {
            Tie();
        }
        
        CentreCamera();
        ResizeCamera();
    }

    void Player1Death()
    {
        player1Lives--;
        if (player1Lives > 0)
        {
            Player1Respawn();
        }
    }
    void Player1Respawn()
    {
        player1 = Instantiate(MenuScript.MenuManager.Characters[(MenuScript.MenuManager.player1Char - 1)], p1Spawn.position, transform.rotation);
        player1.GetComponent<DinoScript>().playerNumber = 1;
        dino1 = player1.GetComponent<Transform>();
    }
    void Player2Death()
    {
        player2Lives--;
        if (player2Lives > 0)
        {
            Player2Respawn();
        }
    }
    void Player2Respawn()
    {
        player2 = Instantiate(MenuScript.MenuManager.Characters[(MenuScript.MenuManager.player2Char - 1)], p2Spawn.position, transform.rotation);
        player2.GetComponent<DinoScript>().playerNumber = 2;
        if (player1Char == player2Char)
        {
            player2.GetComponent<DinoScript>().DupeChar = true;
        }
        dino2 = player2.GetComponent<Transform>();
    }
    void Player2Victory()
    {
        p1lost = true;
        EndText.SetBool("P2Won", true);
        Time.timeScale = 0.5f;
        Invoke("FlashMeteor", 2.5f);
    }
    void Player1Victory()
    {
        p2lost = true;
        EndText.SetBool("P1Won", true);
        Time.timeScale = 0.5f;
        Invoke("FlashMeteor", 2.5f);
    }

    void MeteorEndgame()
    {
        Time.timeScale = 0.5f;
        Invoke("FlashMeteor", 2.5f);
        MeteorEnd.SetActive(true);
        MeteorFlash.Play("Jungle Anim");
    }

    void FlashMeteor()
    {
        //EndText.Play("Nil");
        //Time.timeScale = 1.0f;
        Invoke("Endgame", 2.5f);
        MeteorEnd.SetActive(true);
        MeteorFlash.Play("Jungle Anim");
    }

    IEnumerator Tie()
    {
        p1lost = true;
        p2lost = true;
        EndText.SetBool("Tie", true);
        Time.timeScale = 0.5f;
        Invoke("FlashMeteor", 2.5f);
        yield return null;
    }
    void Endgame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    void CentreCamera()
    {
        //Midpoint position formula (((x1+x2)/2), ((y1+y2)/2))
        Vector3 playersMidpoint = new Vector3((dino1.position.x + dino2.position.x) / 2.0f, (dino1.position.y + dino2.position.y) / 2.0f, Camera.main.transform.position.z);

        //Move Camera
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, playersMidpoint, ref velocity, smoothTime);
    }

    void ResizeCamera()
    {
        //calculate distance
        float dinoDistance = Mathf.Clamp(Vector3.Distance(dino1.position, dino2.position), minCameraSize, maxCameraSize);

        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, dinoDistance, cameraLerpAmount);
    }
}
