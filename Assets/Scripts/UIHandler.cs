using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GracesGames._2DTileMapLevelEditor.Scripts;

/// <summary>
/// Dummy script that handles UI and refers scene management calls to the GameManager singleton
/// </summary>
public class UIHandler : MonoBehaviour
{
    GameManager gMan;
    private GameObject LevelCompleteUI;
    private GameObject LevelFailedUI;
    private GameObject TutorialUI;
    private GameObject MenuUI;
    public GameObject player;

    public GameManager GameManagerInstance
    {
        get { return gMan; }
    }

    // Use this for initialization
    void Start()
    {
        gMan = GameManager.instance;
        LevelCompleteUI = GameObject.FindWithTag("LevelCompleteUI");
        LevelFailedUI = GameObject.FindWithTag("LevelFailedUI");
        MenuUI = GameObject.FindWithTag("MenuButton");

        if (LevelCompleteUI != null && LevelFailedUI != null)
        {
            LevelCompleteUI.SetActive(false);
            LevelFailedUI.SetActive(false);
        }
    }

    public void UnlockLevel(int level)
    {
        GameManager.instance.UnlockLevel(level);
    }

    public void NextLevel()
    {
        GameManager.instance.NextLevel();
    }

    public void LoadLevel(int level)
    {
        GameManager.instance.LoadLevel(level);
    }

    public void ResumeGame()
    {
        GameManager.instance.ResumeGame();
    }
    public void LoadLevel(string levelName)
    {
        GameManager.instance.LoadLevel(levelName);
    }
    public void LoadCurrentLevel()
    {
        GameManager.instance.LoadCurrentLevel();
    }
    public void Victory()
    {
        LevelCompleteUI.SetActive(true);
        MenuUI.SetActive(false);
    }
    public void Failed()
    {
        LevelFailedUI.SetActive(true);
        MenuUI.SetActive(false);
    }

    public void Play()
    {
        if(GameObject.FindWithTag("LevelEditor").GetComponent<LevelEditor>().earthPlaced == true &&
            GameObject.FindWithTag("LevelEditor").GetComponent<LevelEditor>().goalPlaced == true)
        {
            //Destroy(Camera.main);
            Destroy(GameObject.FindWithTag("LevelEditor"));
            Destroy(GameObject.Find("Canvas"));
            Destroy(GameObject.Find("EventSystem"));
            GameObject start = GameObject.Find("Start");
            Instantiate(player, start.transform.position, Quaternion.identity);
        }
    }

    public void Reset()
    {
        GameManager.instance.ResetData();
    }
}
