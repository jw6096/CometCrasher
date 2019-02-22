using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public float offset;

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
                boxCollider.offset = new Vector2(-offset, 0);
                break;
            case 'r':
                boxCollider.offset = new Vector2(offset, 0);
                break;
            case 'u':
                boxCollider.offset = new Vector2(0, offset);
                break;
            case 'd':
                boxCollider.offset = new Vector2(0, -offset);
                break;
            default:
                boxCollider.offset = new Vector2(0, 0);
                break;
        }
    }
}
