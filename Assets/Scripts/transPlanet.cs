using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transPlanet : MonoBehaviour {
    public GameObject wall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Instantiate(wall, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
