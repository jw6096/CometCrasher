using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflector : MonoBehaviour
{
    public bool LR;

    private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log ("Sending Deflection message");
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
