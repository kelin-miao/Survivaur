using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    //Player Stuff
    int player1Char;
    int player2Char;
    //public GameObject[] Characters;
    public Transform p1Spawn;
    public Transform p2Spawn;
    public GameObject player1;
    public GameObject player2;


    //Camera Zoom (Placed here for ease)
    public Transform dino1;
    public Transform dino2;

    //Center Vars
    private const float DISTANCE_MARGIN = 1.0f;

    private Vector3 middlePoint;
    private float distanceFromMiddlePoint;
    private float distanceBetweenDinos;
    private float cameraDistance;
    private float aspectRatio;
    private float fov;
    private float tanFov;

    //Zoom Vars
    public float zoomSpeed = 1;
    public float targetOrtho;
    public float smoothSpeed = 1.0f;
    public float minOrtho = 5.0f;
    public float maxOrtho = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
    //Players
        //Make player 1
        player1 = Instantiate(MenuScript.MenuManager.Characters[(MenuScript.MenuManager.player1Char - 1)], p1Spawn);
        player1.GetComponent<DinoScript>().playerNumber = 1;
        //player1.tag = "Player 1";
        //Make player 2
        player2 = Instantiate(MenuScript.MenuManager.Characters[(MenuScript.MenuManager.player2Char - 1)], p2Spawn);
        player2.GetComponent<DinoScript>().playerNumber = 2;
        //player2.tag = "Player 2";
        //Camera
        //Start Size
        Camera.main.orthographicSize = 20;
        //Centering
        aspectRatio = Screen.width / Screen.height;
        tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);

        //Zooming
        targetOrtho = Camera.main.orthographicSize;
        dino1 = player1.GetComponent<Transform>();
        dino2 = player2.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {









        //Camera
        
        //Keep Cam Centered between dinos
        // Position the camera in the center.
        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = middlePoint.x;
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
    }
}
