using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    public GameObject levelButtonsParent;
    GameObject[] levelButtons;
    GameManager gMan;

    public GameObject startButton;
    public GameObject continueButton;
    GameObject[] menuObjects;
    uint currentMenu;

	// Use this for initialization
	void Start ()
    {
        gMan = GameManager.instance;

        currentMenu = 0;
        menuObjects = new GameObject[this.transform.childCount];

        for(int i = 0; i < this.transform.childCount; i++)
        {
            menuObjects[i] = transform.GetChild(i).gameObject;
            if(menuObjects[i].activeSelf == true)
            {
                currentMenu = (uint)i;
            }
        }

        if(gMan.UnlockedLevels.Length > 1)
        {
            if (gMan.UnlockedLevels[1] == true)
            {
                startButton.SetActive(false);
                continueButton.SetActive(true);
            }
            else
            {
                startButton.SetActive(true);
                continueButton.SetActive(false);
            }
        }

        ChangeMenu(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeMenu(int menuNum)
    {
        if(menuNum < menuObjects.Length)
        {
            menuObjects[currentMenu].SetActive(false);
            menuObjects[menuNum].SetActive(true);
            currentMenu = (uint)menuNum;
        }
        else
        {
            Debug.Log("No such menu exists.");
        }
    }
}