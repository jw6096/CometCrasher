using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvincibleMusic : MonoBehaviour
{
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (sceneName != "MainMenu")
        {
            if (objs.Length > 1)
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Object.Destroy(this.gameObject);
        }

        Debug.Log(sceneName);
    }
}
