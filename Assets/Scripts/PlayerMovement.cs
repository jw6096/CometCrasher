using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rigidbody2D;
    private GameObject[] entities;
    private Animator anim;

    private bool flying;
    private bool ud;
    private bool lr;

    public float force;

    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;
    private UIHandler dummyGM;

    // Use this for initialization
    void Start () {
		rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		flying = false;

        ud = false;
        lr = false;

        entities = GameObject.FindGameObjectsWithTag("EncounterObjects");
        dummyGM = GameObject.FindWithTag("DummyGM").GetComponent<UIHandler>();
	}

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (!flying)
        {
#if UNITY_EDITOR
            if ((Input.GetKey("left") || Input.GetKey("a")) && !ud)
            {
                sendMessage('l');
                rigidbody2D.AddForce(new Vector2(-force, 0));
                flying = true;
                lr = false;
            }

            if ((Input.GetKey("right") || Input.GetKey("d")) && !ud)
            {
                sendMessage('r');
                rigidbody2D.AddForce(new Vector2(force, 0));
                flying = true;
                lr = false;
            }

            if ((Input.GetKey("down") || Input.GetKey("s")) && !lr)
            {
                sendMessage('d');
                rigidbody2D.AddForce(new Vector2(0, -force));
                flying = true;
                ud = false;
            }

            if ((Input.GetKey("up") || Input.GetKey("w")) && !lr)
            {
                sendMessage('u');
                rigidbody2D.AddForce(new Vector2(0, force));
                flying = true;
                ud = false;
            }
#endif
            if (Input.GetMouseButtonDown(0))    // swipe begins
            {
                startPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))    // swipe ends
            {
                endPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }

            if (startPosition != endPosition && startPosition != Vector3.zero && endPosition != Vector3.zero)
            {
                float deltaX = endPosition.x - startPosition.x;
                float deltaY = endPosition.y - startPosition.y;
                if ((deltaX > 0.1f) && !ud) // swipe RIGHT
                {
                    sendMessage('r');
                    rigidbody2D.AddForce(new Vector2(force, 0));
                    flying = true;
                    ud = lr;
                }
                else if ((deltaX < -0.1f) && !ud) // swipe LEFT
                {
                    sendMessage('l');
                    rigidbody2D.AddForce(new Vector2(-force, 0));
                    flying = true;
                    lr = false;
                }
                else if ((deltaY > 0.1f) && !lr) // swipe UP
                {
                    sendMessage('u');
                    rigidbody2D.AddForce(new Vector2(0, force));
                    flying = true;
                    ud = false;
                }
                else if ((deltaY < -0.1f) && !lr) // swipe DOWN
                {
                    sendMessage('d');
                    rigidbody2D.AddForce(new Vector2(0, -force));
                    flying = true;
                    ud = false;
                }

                startPosition = Vector3.zero;
                endPosition = Vector3.zero;
            }
        }

        anim.SetFloat("speedX", rigidbody2D.velocity.x);
        anim.SetFloat("speedY", rigidbody2D.velocity.y);
    }

    private void sendMessage(char x)
    {
        foreach (GameObject obj in entities)
        {
            obj.SendMessage("changeDir", x);
        }
    }

    public void limitDir(bool dir)
    {
        if (dir)
        {
            lr = true;
        } else
        {
            ud = true;
        }
    }

	public void kill() 
	{
		Debug.Log ("I Died Horribly");
        rigidbody2D.velocity = Vector2.zero;
        dummyGM.Failed();
    }

	public void resetFlying()
	{
        if (rigidbody2D.velocity.magnitude <= .1)
        {
            //Debug.Log("Landed");
            rigidbody2D.velocity = Vector2.zero;
            flying = false;
        }
	}

	public void landing() 
	{
		//Debug.Log("Landed on platform");
		rigidbody2D.velocity = new Vector2(0, 0);
		flying = false;
	}

	public void deflectRight()
	{
		//Debug.Log("Deflect Right");
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, rigidbody2D.velocity.x);

        if (rigidbody2D.velocity.x == 0)
        {
            if (rigidbody2D.velocity.y > 0)
            {
                sendMessage('u');
            }
            else
            {
                sendMessage('d');
            }
        }
        else
        {
            if (rigidbody2D.velocity.x > 0)
            {
                sendMessage('r');
            }
            else
            {
                sendMessage('l');
            }
        }
	}

	public void deflectLeft()
	{
		//Debug.Log("Deflect Left");
		rigidbody2D.velocity = new Vector2(-rigidbody2D.velocity.y, -rigidbody2D.velocity.x);

        if (rigidbody2D.velocity.x == 0)
        {
            if (rigidbody2D.velocity.y > 0)
            {
                sendMessage('u');
            }
            else
            {
                sendMessage('d');
            }
        }
        else
        {
            if (rigidbody2D.velocity.x > 0)
            {
                sendMessage('r');
            }
            else
            {
                sendMessage('l');
            }
        }
    }
    public void victory()
    {
        Debug.Log("Victory!");
        rigidbody2D.velocity = Vector2.zero;
        dummyGM.Victory();
    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
		//flying = false;
	}
}
