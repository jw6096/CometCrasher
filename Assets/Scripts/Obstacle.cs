using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool allowMovement = false;
    public float moveForce;
    public int horizontalRange = 0;
    public int verticalRange = 0;

    Vector3 startPos;
    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;

        if(allowMovement)
        {
            rb = GetComponent<Rigidbody2D>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(allowMovement)
        {
            if(horizontalRange != 0)
            {
                if (Mathf.Abs(transform.position.x - startPos.x) >= Mathf.Abs(horizontalRange))
                {
                    transform.position = new Vector3(startPos.x + horizontalRange, startPos.y, startPos.z);
                    rb.velocity = Vector2.zero;
                }
            }
            else if (verticalRange != 0)
            {
                if (Mathf.Abs(transform.position.y - startPos.y) >= Mathf.Abs(verticalRange))
                {
                    transform.position = new Vector3(startPos.x, startPos.y + verticalRange, startPos.z);
                    rb.velocity = Vector2.zero;
                }
            }
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//Debug.Log("Sending death message");
		collision.gameObject.SendMessage("kill");
	}
}
