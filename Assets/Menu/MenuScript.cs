using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public static MenuScript MenuManager;

    //Menu Screens and bools
    bool splashActive = true;
    public GameObject splash;
    bool mainActive = false;
    public GameObject mMenu;
    bool optionsActive = false;
    public GameObject optionsMenu;
    bool TutorialActive = false;
    public GameObject Tutorial;
    bool Tutorial2Active = false;
    public GameObject Tutorial2;
    bool creditsActive = false;
    public GameObject Credits;
    bool mapSelectActive = false;
    public GameObject mapSelect;
    bool charSelectActive = false;
    public GameObject charSelect;
    public GameObject p1CharImage;
    public GameObject p2CharImage;
    public Sprite[] charSprites;
    public GameObject[] Characters; 


    public int mapSelected;
    [Range(1, 4)]
    public int player1Char;
    [Range(1, 4)]
    public int player2Char;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        MenuManager = this;
        player1Char = 1;
        player2Char = 1;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && splashActive == true)
        {
            closeSplash();
            openMain();
        }
        if(charSelectActive)
        {
            p1CharImage.GetComponent<Image>().sprite = charSprites[(player1Char - 1)];
            p2CharImage.GetComponent<Image>().sprite = charSprites[(player2Char - 1)];
        }
    }

    //p1Chubbs
    void p1Chubbs()
    {
        player1Char = 5;
    }
    //p2Chubbs
    void p2Chubbs()
    {
        player2Char = 5;
    }

    //Close Splash Screen
    void closeSplash()
    {
        splash.SetActive(false);
        splashActive = false;
    }

    void openSplash()
    {
        splash.SetActive(true);
        splashActive = true;
    }

    //Open Main Menu
    void openMain()
    {
        mMenu.SetActive(true);
        mainActive = true;
    }

    //Play Button
    void play()
    {
        closeMain();
        openMapSelect();
        //SceneManager.LoadScene("DebugTest");
    }

    //Options Button
    void options()
    {
        closeMain();
        openOptions();
    }

    //Tutorial Button
    void menuTutorial()
    {
        closeMain();
        openTutorial();
    }

    //Next Tutorial Page
    void TutorialNext()
    {
        closeTutorial();
        openTutorial2();
    }

    //Last Tutorial Page
    void TutorialBack()
    {
        closeTutorial2();
        openTutorial();
    }

    //Tutorial Return Button
    void returnTutorial()
    {
        closeTutorial();
        openMain();
    }
    //Tutorial2 Return Button
    void returnTutorial2()
    {
        closeTutorial2();
        openMain();
    }

    //Credits Button
    void credits()
    {
        closeMain();
        openCredits();
    }

    //Credits Return Button
    void returnCredits()
    {
        closeCredits();
        openMain();
    }

    //Quit button
    void quit()
    {
        Application.Quit();
    }

    //Close Main Menu
    void closeMain()
    {
        mMenu.SetActive(false);
        mainActive = false;
    }

    //Return to Main from options
    void returnMain()
    {
        closeOptions();
        openMain();
    }

    //Open Options Menu
    void openOptions()
    {
        optionsMenu.SetActive(true);
        optionsActive = true;
    }

    //close options menu
    void closeOptions()
    {
        optionsMenu.SetActive(false);
        optionsActive = false;
    }

    //Open Tutorial
    void openTutorial()
    {
        Tutorial.SetActive(true);
        TutorialActive = true;
    }

    //Close Tutorial
    void closeTutorial()
    {
        Tutorial.SetActive(false);
        TutorialActive = false;
    }

    //Open Tutorial2
    void openTutorial2()
    {
        Tutorial2.SetActive(true);
        Tutorial2Active = true;
    }

    //Close Tutorial2
    void closeTutorial2()
    {
        Tutorial2.SetActive(false);
        Tutorial2Active = false;
    }

    //Open Credits
    void openCredits()
    {
        Credits.SetActive(true);
        creditsActive = true;
    }

    //Close Credits
    void closeCredits()
    {
        Credits.SetActive(false);
        creditsActive = false;
    }

    //Open map select
    void openMapSelect()
    {
        mapSelect.SetActive(true);
        mapSelectActive = true;
    }
    //close map selection
    void closeMapSelect()
    {
        mapSelect.SetActive(false);
        mapSelectActive = false;
    }

    //return from map select
    void returnMapSelect()
    {
        closeMapSelect();
        openMain();
    }
    //Open character select
    void openCharSelect()
    {
        charSelect.SetActive(true);
        charSelectActive = true;
    }
    //close character selection
    void closeCharSelect()
    {
        charSelect.SetActive(false);
        charSelectActive = false;
    }

    //return Character select
    void returnCharSelect()
    {
        closeCharSelect();
        openMapSelect();
    }
    //reset this script
    private void Reset()
    {
        openSplash();
        closeMain();
        closeOptions();
        closeMapSelect();
        closeCharSelect();
    }
    //map 1 selected
    void map1Selected()
    {
        mapSelected = 1;
        closeMapSelect();
        openCharSelect();
    }
    //map 2 selected
    void map2Selected()
    {
        mapSelected = 2;
        closeMapSelect();
        openCharSelect();
    }
    //Player 1 next char
    void p1Next()
    {
        if(player1Char < 4)
        {
            ++player1Char;
        }
        else
        {
            player1Char = 1;
        }
        
    }
    //Player 1 Previous char
    void p1Prev()
    {
        if (player1Char > 1)
        {
            --player1Char;
        }
        else
        {
            player1Char = 4;
        }
    }
    //Player 1 next char
    void p2Next()
    {
        if (player2Char < 4)
        {
            ++player2Char;
        }
        else
        {
            player2Char = 1;
        }

    }
    //Player 1 Previous char
    void p2Prev()
    {
        if (player2Char > 1)
        {
            --player2Char;
        }
        else
        {
            player2Char = 4;
        }
    }
    void startGame()
    {
        if(mapSelected == 1)
        {
            //load map 1
            SceneManager.LoadScene("Volcano Level");
        }
        if (mapSelected == 2)
        {
            //load map 1
            SceneManager.LoadScene("TestLevel");
        }
        Destroy(gameObject);
    }
}