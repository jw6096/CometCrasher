using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
        if(GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else if(GameManager.instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UnlockLevel(uint level)
    {
        unlockedLevels[level] = true;
    }

    public void NextLevel()
    {
        if(unlockedLevels[currentLevel + 1] == true)
        {
            LoadLevel(currentLevel + 1);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
