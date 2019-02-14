using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflector : MonoBehaviour {

	public bool LR;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (Vector3.Distance (collision.gameObject.transform.position, gameObject.transform.position) <= 1f) 
		{
			Debug.Log ("Sending Deflection message");
			collision.gameObject.transform.position = gameObject.transform.position;

			if (LR) 
			{
				collision.gameObject.SendMessage ("deflectRight");
			} 
			else 
			{
				collision.gameObject.SendMessage ("deflectLeft");
			}
		}
	}
}
