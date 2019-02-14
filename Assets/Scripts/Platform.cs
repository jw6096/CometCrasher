using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Vector3.Distance(collision.gameObject.transform.position, gameObject.transform.position) <= 0.1f)
		{
			Debug.Log("Sending landing message");
			collision.gameObject.transform.position = gameObject.transform.position;
			collision.gameObject.SendMessage("landing");			
		}
	}
}
