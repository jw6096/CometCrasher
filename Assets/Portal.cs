using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PortalNum
{
    Portal1,
    Portal2
}

public class Portal : MonoBehaviour {

    public PortalNum portal;

    private float cooldown = 0;
    private List<GameObject> targets = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        GameObject[] temp = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in temp)
        {
            if (obj.GetComponent<Portal>() != null)
            {
                if (portal != obj.GetComponent<Portal>().portal)
                {
                    targets.Add(obj);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cooldown <= 0)
        {
            int rand = Random.Range(0, targets.Count);

            //Debug.Log("Sending landing message");
            collision.gameObject.transform.position = targets[rand].transform.position;

            foreach (GameObject obj in targets)
            {
                obj.SendMessage("cool");
            }

            //collision.gameObject.SendMessage("landing");
        }
    }

    private void cool()
    {
        cooldown = 1;
    }
}
