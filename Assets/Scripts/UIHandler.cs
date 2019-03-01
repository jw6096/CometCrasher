using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dummy script that handles UI and refers scene management calls to the GameManager singleton
/// </summary>
public class UIHandler : MonoBehaviour
{
    GameManager gMan;
    private GameObject LevelCompleteUI;
    private GameObject LevelFailedUI;

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
    }
    public void Failed()
    {
        LevelFailedUI.SetActive(true);
    }
}
