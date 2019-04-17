using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseUI()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (gameObject.transform.GetChild(4).GetComponent<Text>().text == "N/A")
        {
            gameObject.SetActive(false);
        }
    }
}
