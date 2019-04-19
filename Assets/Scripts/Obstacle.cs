using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool allowMovement = false;
    public float moveForce;
    [Tooltip("How long the obstacle stops at an endpoint.")]
    public float pauseTime = 0.3f;

    //Movement ranges, only one can be active at a time
    [Tooltip("Horizontal Range of movement. Ex: 4 = 4 left and right.")]
    public int horizontalRange = 0;
    [Tooltip("Vertical Range of movement. Ex: 4 = 4 up and down.")]
    public int verticalRange = 0;

    Vector3 startPos;
    Rigidbody2D rb;
    float timePaused = 0.0f;
    bool paused;

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
        //Check if obstacle moves
		if(allowMovement)
        {
            //Check if horizontal
            if(horizontalRange != 0)
            {
                if (Mathf.Abs(transform.position.x - startPos.x) >= Mathf.Abs(horizontalRange))
                {
                    //Snap position and stop
                    transform.position = new Vector3(startPos.x + horizontalRange + (-0.001f * Mathf.Sign(horizontalRange)), startPos.y, startPos.z);
                    rb.velocity = Vector2.zero;
                    paused = true;
                }

                UpdatePauseTime(horizontalRange);

                if(paused == false)
                {
                    rb.AddForce(new Vector2(moveForce * Mathf.Sign(horizontalRange), 0.0f));
                }
            }
            //Check if vertical
            else if (verticalRange != 0)
            {
                if (Mathf.Abs(transform.position.y - startPos.y) >= Mathf.Abs(verticalRange))
                {
                    //Snap position and stop
                    transform.position = new Vector3(startPos.x, startPos.y + verticalRange + (-0.001f * Mathf.Sign(verticalRange)), startPos.z);
                    rb.velocity = Vector2.zero;
                    paused = true;
                }

                UpdatePauseTime(verticalRange);

                if(paused == false)
                {
                    rb.AddForce(new Vector2(0.0f, moveForce * Mathf.Sign(verticalRange)));
                }
            }
        }
	}

    private void UpdatePauseTime(int inputDirection)
    {
        //Check if paused
        if (paused)
        {
            timePaused += Time.deltaTime;   //Update time

            //Is object pause time over?
            if (timePaused >= pauseTime)
            {
                paused = false; //Unpause object

                //Swap directions
                if(inputDirection == horizontalRange)
                {
                    horizontalRange *= -1;
                }
                else
                {
                    verticalRange *= -1;
                }

                timePaused = 0.0f;  //Reset pause time
            }
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//Debug.Log("Sending death message");
		collision.gameObject.SendMessage("kill");
	}
}