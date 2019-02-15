using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start ()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void changeDir(char x)
    {
        switch (x)
        {
            case 'l':
                boxCollider.offset = new Vector2(-.08f, 0);
                break;
            case 'r':
                boxCollider.offset = new Vector2(.08f, 0);
                break;
            case 'u':
                boxCollider.offset = new Vector2(0, .08f);
                break;
            case 'd':
                boxCollider.offset = new Vector2(0, -.08f);
                break;
            default:
                boxCollider.offset = new Vector2(0, 0);
                break;

        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        //Debug.Log("Sending landing message");
        collision.gameObject.transform.position = gameObject.transform.position;
        collision.gameObject.SendMessage("landing");
	}
}
