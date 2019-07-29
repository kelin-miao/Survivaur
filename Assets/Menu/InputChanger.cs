using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputChanger : MonoBehaviour
{
    //Input
    GameObject menuPanelp1;

    GameObject menuPanelp2;

    Event keyEvent;

    Text buttonText;

    KeyCode newKey;

    bool waitingForKey = false;

    string KeyToBind;
    // Start is called before the first frame update
    void Start()
    {
        menuPanelp1 = gameObject.transform.Find("Player 1 Input Panel").gameObject;
        menuPanelp2 = gameObject.transform.Find("Player 2 Input Panel").gameObject;

        //Set Text boxes to current inputs
        menuPanelp1.transform.Find("Attack").GetComponentInChildren<Text>().text = InputManager.IM.p1attack1.ToString();
        menuPanelp1.transform.Find("Ability").GetComponentInChildren<Text>().text = InputManager.IM.p1special.ToString();
        menuPanelp1.transform.Find("Jump").GetComponentInChildren<Text>().text = InputManager.IM.p1jump.ToString();
        menuPanelp1.transform.Find("Left").GetComponentInChildren<Text>().text = InputManager.IM.p1left.ToString();
        menuPanelp1.transform.Find("Right").GetComponentInChildren<Text>().text = InputManager.IM.p1right.ToString();
        menuPanelp1.transform.Find("Block").GetComponentInChildren<Text>().text = InputManager.IM.p1block.ToString();

        //Set Text boxes to current inputs
        menuPanelp2.transform.Find("Attack").GetComponentInChildren<Text>().text = InputManager.IM.p2attack1.ToString();
        menuPanelp2.transform.Find("Ability").GetComponentInChildren<Text>().text = InputManager.IM.p2special.ToString();
        menuPanelp2.transform.Find("Jump").GetComponentInChildren<Text>().text = InputManager.IM.p2jump.ToString();
        menuPanelp2.transform.Find("Left").GetComponentInChildren<Text>().text = InputManager.IM.p2left.ToString();
        menuPanelp2.transform.Find("Right").GetComponentInChildren<Text>().text = InputManager.IM.p2right.ToString();
        menuPanelp2.transform.Find("Block").GetComponentInChildren<Text>().text = InputManager.IM.p2block.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        keyEvent = Event.current;
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
            //P1 Inputs
            if(KeyToBind == "P1Attack")
            {
                InputManager.IM.p1attack1 = newKey;
                PlayerPrefs.SetString("Player 1 Front Attack", InputManager.IM.p1attack1.ToString());
                menuPanelp1.transform.Find("Attack").GetComponentInChildren<Text>().text = InputManager.IM.p1attack1.ToString();
            }
            if (KeyToBind == "P1Ability")
            {
                InputManager.IM.p1special = newKey;
                PlayerPrefs.SetString("Player 1 Special Ability", InputManager.IM.p1special.ToString());
                menuPanelp1.transform.Find("Ability").GetComponentInChildren<Text>().text = InputManager.IM.p1special.ToString();
            }
            if (KeyToBind == "P1Jump")
            {
                InputManager.IM.p1jump = newKey;
                PlayerPrefs.SetString("Player 1 Jump", InputManager.IM.p1jump.ToString());
                menuPanelp1.transform.Find("Jump").GetComponentInChildren<Text>().text = InputManager.IM.p1jump.ToString();
            }
            if (KeyToBind == "P1Left")
            {
                InputManager.IM.p1left = newKey;
                PlayerPrefs.SetString("Player 1 Left", InputManager.IM.p1left.ToString());
                menuPanelp1.transform.Find("Left").GetComponentInChildren<Text>().text = InputManager.IM.p1left.ToString();
            }
            if (KeyToBind == "P1Right")
            {
                InputManager.IM.p1right = newKey;
                PlayerPrefs.SetString("Player 1 Right", InputManager.IM.p1right.ToString());
                menuPanelp1.transform.Find("Right").GetComponentInChildren<Text>().text = InputManager.IM.p1right.ToString();
            }
            if (KeyToBind == "P1Block")
            {
                InputManager.IM.p1block = newKey;
                PlayerPrefs.SetString("Player 1 Block", InputManager.IM.p1block.ToString());
                menuPanelp1.transform.Find("Block").GetComponentInChildren<Text>().text = InputManager.IM.p1block.ToString();
            }
            //P2 Inputs
            if (KeyToBind == "P2Attack")
            {
                InputManager.IM.p2attack1 = newKey;
                PlayerPrefs.SetString("Player 2 Front Attack", InputManager.IM.p2attack1.ToString());
                menuPanelp2.transform.Find("Attack").GetComponentInChildren<Text>().text = InputManager.IM.p2attack1.ToString();
            }
            if (KeyToBind == "P2Ability")
            {
                InputManager.IM.p2special = newKey;
                PlayerPrefs.SetString("Player 2 Special Ability", InputManager.IM.p2special.ToString());
                menuPanelp2.transform.Find("Ability").GetComponentInChildren<Text>().text = InputManager.IM.p2special.ToString();
            }
            if (KeyToBind == "P2Jump")
            {
                InputManager.IM.p2jump = newKey;
                PlayerPrefs.SetString("Player 2 Jump", InputManager.IM.p2jump.ToString());
                menuPanelp2.transform.Find("Jump").GetComponentInChildren<Text>().text = InputManager.IM.p2jump.ToString();
            }
            if (KeyToBind == "P2Left")
            {
                InputManager.IM.p2left = newKey;
                PlayerPrefs.SetString("Player 2 Left", InputManager.IM.p2left.ToString());
                menuPanelp2.transform.Find("Left").GetComponentInChildren<Text>().text = InputManager.IM.p2left.ToString();
            }
            if (KeyToBind == "P2Right")
            {
                InputManager.IM.p2right = newKey;
                PlayerPrefs.SetString("Player 2 Right", InputManager.IM.p2right.ToString());
                menuPanelp2.transform.Find("Right").GetComponentInChildren<Text>().text = InputManager.IM.p2right.ToString();
            }
            if (KeyToBind == "P2Block")
            {
                InputManager.IM.p2block = newKey;
                PlayerPrefs.SetString("Player 2 Block", InputManager.IM.p2block.ToString());
                menuPanelp2.transform.Find("Block").GetComponentInChildren<Text>().text = InputManager.IM.p2block.ToString();
            }
        }
    }

    void P1DefaultInputs()
    {
        InputManager.IM.p1attack1 = KeyCode.V;
        PlayerPrefs.SetString("Player 1 Front Attack", InputManager.IM.p1attack1.ToString());

        InputManager.IM.p1special = KeyCode.B;
        PlayerPrefs.SetString("Player 1 Special Ability", InputManager.IM.p1special.ToString());

        InputManager.IM.p1jump = KeyCode.W;
        PlayerPrefs.SetString("Player 1 Jump", InputManager.IM.p1jump.ToString());

        InputManager.IM.p1left = KeyCode.A;
        PlayerPrefs.SetString("Player 1 Left", InputManager.IM.p1left.ToString());

        InputManager.IM.p1right = KeyCode.D;
        PlayerPrefs.SetString("Player 1 Right", InputManager.IM.p1right.ToString());

        InputManager.IM.p1block = KeyCode.S;
        PlayerPrefs.SetString("Player 1 Block", InputManager.IM.p1block.ToString());

        //Set Text boxes to current inputs
        menuPanelp1.transform.Find("Attack").GetComponentInChildren<Text>().text = InputManager.IM.p1attack1.ToString();
        menuPanelp1.transform.Find("Ability").GetComponentInChildren<Text>().text = InputManager.IM.p1special.ToString();
        menuPanelp1.transform.Find("Jump").GetComponentInChildren<Text>().text = InputManager.IM.p1jump.ToString();
        menuPanelp1.transform.Find("Left").GetComponentInChildren<Text>().text = InputManager.IM.p1left.ToString();
        menuPanelp1.transform.Find("Right").GetComponentInChildren<Text>().text = InputManager.IM.p1right.ToString();
        menuPanelp1.transform.Find("Block").GetComponentInChildren<Text>().text = InputManager.IM.p1block.ToString();
    }
    void P2DefaultInputs()
    {
        InputManager.IM.p2attack1 = KeyCode.RightBracket;
        PlayerPrefs.SetString("Player 2 Front Attack", InputManager.IM.p2attack1.ToString());

        InputManager.IM.p2special = KeyCode.LeftBracket;
        PlayerPrefs.SetString("Player 2 Special Ability", InputManager.IM.p2special.ToString());

        InputManager.IM.p2jump = KeyCode.UpArrow;
        PlayerPrefs.SetString("Player 2 Jump", InputManager.IM.p2jump.ToString());

        InputManager.IM.p2left = KeyCode.LeftArrow;
        PlayerPrefs.SetString("Player 2 Left", InputManager.IM.p2left.ToString());

        InputManager.IM.p2right = KeyCode.RightArrow;
        PlayerPrefs.SetString("Player 2 Right", InputManager.IM.p2right.ToString());

        InputManager.IM.p2block = KeyCode.DownArrow;
        PlayerPrefs.SetString("Player 2 Block", InputManager.IM.p2block.ToString());

        //Set Text boxes to current inputs
        menuPanelp2.transform.Find("Attack").GetComponentInChildren<Text>().text = InputManager.IM.p2attack1.ToString();
        menuPanelp2.transform.Find("Ability").GetComponentInChildren<Text>().text = InputManager.IM.p2special.ToString();
        menuPanelp2.transform.Find("Jump").GetComponentInChildren<Text>().text = InputManager.IM.p2jump.ToString();
        menuPanelp2.transform.Find("Left").GetComponentInChildren<Text>().text = InputManager.IM.p2left.ToString();
        menuPanelp2.transform.Find("Right").GetComponentInChildren<Text>().text = InputManager.IM.p2right.ToString();
        menuPanelp2.transform.Find("Block").GetComponentInChildren<Text>().text = InputManager.IM.p2block.ToString();
    }
    void P1Attack()
    {
        KeyToBind = "P1Attack";
        waitingForKey = true;
    }
    void P1Ability()
    {
        KeyToBind = "P1Ability";
        waitingForKey = true;
    }
    void P1Jump()
    {
        KeyToBind = "P1Jump";
        waitingForKey = true;
    }
    void P1Left()
    {
        KeyToBind = "P1Left";
        waitingForKey = true;
    }
    void P1Right()
    {
        KeyToBind = "P1Right";
        waitingForKey = true;
    }
    void P1Block()
    {
        KeyToBind = "P1Block";
        waitingForKey = true;
    }
    //
    void P2Attack()
    {
        KeyToBind = "P2Attack";
        waitingForKey = true;
    }
    void P2Ability()
    {
        KeyToBind = "P2Ability";
        waitingForKey = true;
    }
    void P2Jump()
    {
        KeyToBind = "P2Jump";
        waitingForKey = true;
    }
    void P2Left()
    {
        KeyToBind = "P2Left";
        waitingForKey = true;
    }
    void P2Right()
    {
        KeyToBind = "P2Right";
        waitingForKey = true;
    }
    void P2Block()
    {
        KeyToBind = "P2Block";
        waitingForKey = true;
    }
    void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
