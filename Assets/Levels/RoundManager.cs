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
    [Range (0, 3)]
    public int player1Lives = 3;
    [Range (0, 3)]
    public int player2Lives = 3;
    bool p1lost = false;
    bool p2lost = false;
    //public GameObject[] Characters;
    public Transform p1Spawn;
    public Transform p2Spawn;
    public GameObject player1;
    public GameObject player2;
    public GameObject p2Wintext;
    public GameObject p1Wintext;
    public Text p1LifeCount;
    public Text p2LifeCount;


    //Camera Zoom (Placed here for ease)
    public Transform dino1;
    public Transform dino2;

    //Center Vars

    private const float DISTANCE_MARGIN = 1.0f;

    //private Vector3 middlePoint;
   // private float distanceFromMiddlePoint;
    //private float distanceBetweenDinos;
    //private float cameraDistance;
    private float aspectRatio;
    //private float fov;
    //private float tanFov;

    //Zoom Vars
    private Vector3 velocity = Vector3.zero;
    [SerializeField] public float smoothTime = 0.25f;
    

    public float zoomSpeed = 3;
    public float targetOrtho;
    public float smoothSpeed = 1.0f;
    public float minOrtho = 7.0f;
    public float maxOrtho = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Players
        //Make player 1
        player1 = Instantiate(MenuScript.MenuManager.Characters[(MenuScript.MenuManager.player1Char - 1)], p1Spawn.position, transform.rotation);
        player1.GetComponent<DinoScript>().playerNumber = 1;
        //player1.tag = "Player 1";
        //Make player 2
        player2 = Instantiate(MenuScript.MenuManager.Characters[(MenuScript.MenuManager.player2Char - 1)], p2Spawn.position, transform.rotation);
        player2.GetComponent<DinoScript>().playerNumber = 2;
        //player2.tag = "Player 2";
        //Camera
        //Start Size

        //Camera.main.orthographicSize = 20;
        //"The orthographicSize is half the size of the vertical viewing volume. The horizontal size of the viewing volume depends on the aspect ratio."
        //Centering
        aspectRatio = Screen.width / Screen.height;
        //tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);

        //Zooming
        //targetOrtho = Camera.main.orthographicSize;
        dino1 = player1.GetComponent<Transform>();
        dino2 = player2.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Handle Death and respawn
        if(player1.GetComponent<DinoScript>().Health <= 0)
        {
            Player1Death();
        }

        if (player2.GetComponent<DinoScript>().Health <= 0)
        {
            Player2Death();
        }

        if(player1Lives <= 0 && p1lost == false)
        {
            Player2Victory();
        }
        if (player2Lives <= 0 && p2lost == false)
        {
            Player1Victory();
        }
        p1LifeCount.text = "Player 1 Lives: " + player1Lives;
        p2LifeCount.text = "Player 2 Lives: " + player2Lives;
        if(player1Lives <= 0 && player2Lives <= 0)
        {
            Tie();
        }

        CentreCamera();
        ResizeCamera();
    }
    void Player1Death()
    {
        player1Lives--;
        if(player1Lives > 0)
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
        dino2 = player2.GetComponent<Transform>();
    }
    void Player2Victory()
    {
        p1lost = true;
        p2Wintext.SetActive(true);
        Time.timeScale = 0.5f;
        Invoke("Endgame", 2.5f);
    }
    void Player1Victory()
    {
        p2lost = true;
        p1Wintext.SetActive(true);
        Time.timeScale = 0.5f;
        Invoke("Endgame", 2.5f);

    }
    void Tie()
    {
        p1lost = true;
        p2lost = true;
        Time.timeScale = 0.5f;
        Invoke("Endgame", 2.5f);
    }
    void Endgame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    void CentreCamera()
    {


        //Midpoint position formula (((x1+x2)/2), ((y1+y2)/2))
        Vector3 playersMidpoint = new Vector3((dino1.position.x + dino2.position.x)/2.0f, (dino1.position.y + dino2.position.y) / 2.0f, Camera.main.transform.position.z);



        //Move Camera
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, playersMidpoint, ref velocity, smoothTime);


        /*
        //Camera

        //Keep Cam Centered between dinos

        // Position the camera in the center.

        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = middlePoint.x;
        newCameraPos.y = middlePoint.y;
        Camera.main.transform.position = newCameraPos;

        // Find center point between Dinos.
        Vector3 vectorBetweenDinos = dino2.position - dino1.position;
        middlePoint = dino1.position + 0.5f * vectorBetweenDinos;

        // Calculate the new distance.
        distanceBetweenDinos = vectorBetweenDinos.magnitude;
        cameraDistance = (distanceBetweenDinos / 2.0f / aspectRatio) / tanFov;

        // Move camera to new position.
        Vector3 dir = (Camera.main.transform.position - middlePoint).normalized;
        Camera.main.transform.position = middlePoint + dir * (cameraDistance + DISTANCE_MARGIN);

        // Zoom out as distance between increases
        if (distanceBetweenDinos != 0.0f)
        {
            targetOrtho = distanceBetweenDinos * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
        */
    }

    void ResizeCamera()
    {
        //calculate x distance 
        float xDistance = Mathf.Clamp(Mathf.Abs(dino1.position.x - dino2.position.x), 12.0f, 24.0f);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, xDistance/Screen.width * Screen.height, 0.05f);
    }
}
