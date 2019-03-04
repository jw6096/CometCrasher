using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    public GameObject levelButtonsParent;
    public GameObject levelButtonPrefab;
    Button[] levelButtons;
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

        //Instantiate buttons for each existing level
        for(int i = 1; i <= gMan.UnlockedLevels.Length; i++)
        {
            GameObject buttonTemp = Instantiate(levelButtonPrefab, levelButtonsParent.transform);

            int tempInt = i;

            buttonTemp.GetComponent<Button>().onClick.AddListener(delegate { gMan.LoadLevel(tempInt); });
            buttonTemp.GetComponentInChildren<Text>().text = "Level " + i;
        }

        levelButtons = levelButtonsParent.GetComponentsInChildren<Button>();

        //for (int i = 0; i < levelButtonsParent.transform.childCount; i++)
        //{
        //    levelButtons[i] = levelButtonsParent.transform.GetChild(i).gameObject;
        //}

        if (gMan.UnlockedLevels.Length > 1)
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

        UpdateLevelLocks();
	}

    void UpdateLevelLocks()
    {
        int levelLength = gMan.UnlockedLevels.Length;
        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i < levelLength)
            {
                if (gMan.UnlockedLevels[i] == true)
                {
                    levelButtons[i].GetComponent<Button>().interactable = true;
                }
                else
                {
                    levelButtons[i].GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                levelButtons[i].GetComponent<Button>().interactable = false;
            }
        }
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