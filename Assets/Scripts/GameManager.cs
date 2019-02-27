using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int levelCount;
    int currentLevel;
    bool[] unlockedLevels;

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
        if(GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else if(GameManager.instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);

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
    void Start ()
    {
        currentLevel = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UnlockLevel(int level)
    {
        unlockedLevels[level-1] = true;
    }

    public void NextLevel()
    {
        if(unlockedLevels[currentLevel] == true)
        {
            LoadLevel(currentLevel + 1);
        }
    }

    public void LoadLevel(int level)
    {
        if (level <= levelCount)
        {
            currentLevel = level;
            SceneManager.LoadScene(level);
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
    /// <summary>
    /// Loads the current level (in-game levels, not scenes)
    /// </summary>
    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}