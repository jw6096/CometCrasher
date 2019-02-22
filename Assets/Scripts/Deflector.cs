using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflector : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    public bool LR;

	// Use this for initialization
	void Start ()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

	// Update is called once per frame
	void Update () {

    }

    public void changeDir(char x)
    {
        switch (x)
        {
            case 'l':
                boxCollider.offset = new Vector2(-.5f, 0);
                break;
            case 'r':
                boxCollider.offset = new Vector2(.5f, 0);
                break;
            case 'u':
                boxCollider.offset = new Vector2(0, .5f);
                break;
            case 'd':
                boxCollider.offset = new Vector2(0, -.5f);
                break;
            default:
                boxCollider.offset = new Vector2(0, 0);
                break;

        }
    }

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
