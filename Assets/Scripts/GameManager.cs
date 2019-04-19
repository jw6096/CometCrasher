using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int levelCount;
    public int currentLevel;
    bool[] unlockedLevels;

    int savedLevel;

    public bool[] UnlockedLevels
    {
        get { return unlockedLevels; }
    }

    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    private void Awake()
    {
        //Make sure only one instance exists, singleton
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else if (GameManager.instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);

        //Get how many levels there are
        levelCount = SceneManager.sceneCountInBuildSettings - 1;

        //Handle potential error from no levels
        if (levelCount <= 0)
        {
            Debug.Log("No current levels: If no levels exist, do not start");
            levelCount = 1;
        }

        unlockedLevels = new bool[levelCount];
        UnlockLevel(1);
    }

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("Level") && PlayerPrefs.GetInt("Level") != 1)
        {
            currentLevel = PlayerPrefs.GetInt("Level");

            for (int i = 0; i < currentLevel; i++)
                UnlockLevel(i);

            SceneManager.LoadScene(0);
        }
        else
            SceneManager.LoadScene(0);
    }

    public void UnlockLevel(int level)
    {
        unlockedLevels[level] = true;
    }

    public void NextLevel()
    {
        UnlockLevel(currentLevel + 1);
        LoadLevel(currentLevel + 1);
        //currentLevel++;

        PlayerPrefs.SetInt("Level", currentLevel);
    }

    public void LoadLevel(int level)
    {
        if (level <= levelCount)
        {
            SceneManager.LoadScene(level);
            currentLevel = PlayerPrefs.GetInt("Level");

            if (level > currentLevel)
                currentLevel = level;
        }
        else
        {
            Debug.Log("Level does not exist: given level exceeds levelCount");
        }
    }
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ResumeGame()
    {
        int lastLevel = 0;
        for (int i = 0; i < unlockedLevels.Length; i++)
        {
            if (unlockedLevels[i] == false)
            {
                LoadLevel(lastLevel);
                return;
            }
            lastLevel++;
        }
    }

    public void ResetData()
    {
        //PlayerPrefs.SetInt("Level", 1);

        //for (int i = 0; i < levelCount; i++)
            //unlockedLevels[i] = false;

        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// Loads the current level (in-game levels, not scenes)
    /// </summary>
    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
