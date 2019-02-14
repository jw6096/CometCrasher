using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rigidbody2D;
	private bool flying;

	public float force;

	// Use this for initialization
	void Start () {
		rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		flying = false;
	}

	// Update is called once per frame
	void Update () {
		if ((Input.GetKey("left") || Input.GetKey("a")) && !flying)
		{
			rigidbody2D.AddForce(new Vector2(-force, 0));
			flying = true;
		}

		if ((Input.GetKey("right") || Input.GetKey("d")) && !flying)
		{
			rigidbody2D.AddForce(new Vector2(force, 0));
			flying = true;
		}

		if ((Input.GetKey("down") || Input.GetKey("s")) && !flying)
		{
			rigidbody2D.AddForce(new Vector2(0, -force));
			flying = true;
		}

		if ((Input.GetKey("up") || Input.GetKey("w")) && !flying)
		{
			rigidbody2D.AddForce(new Vector2(0, force));
			flying = true;
		}
	}

	public void kill() 
	{
		Debug.Log ("I Died Horribly");
	}

	public void resetFlying()
	{
		Debug.Log("Landed");
		flying = false;
	}

	public void landing() 
	{
		Debug.Log("Landed on platform");
		rigidbody2D.velocity = new Vector2(0, 0);
		flying = false;
	}

	public void deflectRight()
	{
		Debug.Log("Deflect Right");
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, rigidbody2D.velocity.x);
	}

	public void deflectLeft()
	{
		Debug.Log("Deflect Left");
		rigidbody2D.velocity = new Vector2(-rigidbody2D.velocity.y, -rigidbody2D.velocity.x);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//flying = false;
	}
}
