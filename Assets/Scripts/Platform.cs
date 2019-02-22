﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
        //Debug.Log("Sending landing message");
        collision.gameObject.transform.position = gameObject.transform.position;
        collision.gameObject.SendMessage("landing");
	}
}
