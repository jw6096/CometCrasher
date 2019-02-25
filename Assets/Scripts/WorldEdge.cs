using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEdge : MonoBehaviour {
    private float xPos, xNeg, yPos, yNeg, ySiz, xSiz, yCen, xCen;
    private BoxCollider2D[] boxCollider2D;
    private GameObject[] gameObjects;

	// Use this for initialization
	void Start () {
        gameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        boxCollider2D = gameObject.GetComponents<BoxCollider2D>();

        xPos = 0;
        xNeg = 0;
        yPos = 0;
        yNeg = 0;

        foreach (GameObject gObject in gameObjects)
        {
            if (gObject.activeInHierarchy)
            {
                float x = gObject.transform.position.x;
                float y = gObject.transform.position.y;

                if (x > 0 && x > xPos)
                {
                    xPos = x;
                }
                else if (x < 0 && x < xNeg)
                {
                    xNeg = x;
                }

                if (y > 0 && x > yPos)
                {
                    yPos = y;
                }
                else if (y < 0 && x < yNeg)
                {
                    yNeg = y;
                }
            }
        }
        
        xPos += 3;
        yPos += 3;
        xNeg -= 3;
        yNeg -= 3;

        xCen = (xPos + xNeg) / 2;
        yCen = (yPos + yNeg) / 2;

        xSiz = (xPos - xNeg);
        ySiz = (yPos - yNeg);

        boxCollider2D[0].offset = new Vector2(xPos, yCen);
        boxCollider2D[0].size = new Vector2(.1f, ySiz);

        boxCollider2D[1].offset = new Vector2(xNeg, yCen);
        boxCollider2D[1].size = new Vector2(.1f, ySiz);

        boxCollider2D[2].offset = new Vector2(xCen, yPos);
        boxCollider2D[2].size = new Vector2(xSiz, .1f);

        boxCollider2D[3].offset = new Vector2(xCen, yNeg);
        boxCollider2D[3].size = new Vector2(xSiz, .1f);
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Sending death message");
        collision.gameObject.SendMessage("kill");
    }
}
