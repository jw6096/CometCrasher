using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitPlatform : MonoBehaviour {
    public bool direction;

    private BoxCollider2D boxCollider;

    // Use this for initialization
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
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
        //Debug.Log("Sending landing message");
        collision.gameObject.transform.position = gameObject.transform.position;
        collision.gameObject.SendMessage("landing");
        collision.gameObject.SendMessage("limitDir", direction);
    }
}
