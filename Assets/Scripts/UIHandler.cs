using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dummy script that handles UI and refers scene management calls to the GameManager singleton
/// </summary>
public class UIHandler : MonoBehaviour
{

    GameManager gMan;

    public GameManager GameManagerInstance
    {
        get { return gMan; }
    }

	// Use this for initialization
	void Start ()
    {
        gMan = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
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
}
