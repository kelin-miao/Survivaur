﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager IM;

    public KeyCode p1jump { get; set; }
    public KeyCode p1attack1 { get; set; }
    public KeyCode p1special { get; set; }
    public KeyCode p1left { get; set; }
    public KeyCode p1right { get; set; }
    public KeyCode p1block { get; set; }


    public KeyCode p2jump { get; set; }
    public KeyCode p2attack1 { get; set; }
    public KeyCode p2special { get; set; }
    public KeyCode p2left { get; set; }
    public KeyCode p2right { get; set; }
    public KeyCode p2block { get; set; }



    void Awake()
    {
        
        if (IM == null)
        {
            DontDestroyOnLoad(gameObject);
            IM = this;
        }
        else if(IM != this)
        {
            Destroy(gameObject);
        }
        
        //Assign Keycodes when game starts
        //Player 1
        p1jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 1 Jump", "W"));
        p1attack1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 1 Front Attack", "V"));
        p1special = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 1 Special Ability", "B"));
        p1left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 1 Left", "A"));
        p1right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 1 Right", "D"));
        p1block = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 1 Block", "S"));

        //Player 2
        p2jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 2 Jump", "UpArrow"));
        p2attack1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 2 Front Attack", "RightBracket"));
        p2special = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 2 Special Ability", "LeftBracket"));
        p2left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 2 Left", "LeftArrow"));
        p2right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 2 Right", "RightArrow"));
        p2block = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player 2 Block", "DownArrow"));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        
    }
}
