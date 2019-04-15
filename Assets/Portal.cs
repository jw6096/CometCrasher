using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public enum PortalNum
{
    Portal1,
    Portal2
}
*/

public class Portal : MonoBehaviour {

    //public PortalNum portal;
    public GameObject targetPortal;

    private float cooldown = 0;
    //private List<GameObject> targets = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        /*
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
        */

        if (!targetPortal)
        {
            Debug.Log("No portal specified. Trying to find portal to pair.");

            GameObject[] temp = GameObject.FindGameObjectsWithTag("EncounterObjects");

            foreach (GameObject obj in temp)
            {
                if (obj.GetComponent<Portal>() != null && obj != gameObject)
                {
                    targetPortal = obj;
                }
            }
        }

        if (!targetPortal)
        {
            Debug.Log("No portal found. Transitioning to platform for game integrity.");

            gameObject.GetComponent<Platform>().enabled = true;
            gameObject.GetComponent<Portal>().enabled = false;
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
        if (enabled)
        {
            if (cooldown <= 0)
            {
                /*
                int rand = Random.Range(0, targets.Count);

                //Debug.Log("Sending landing message");
                collision.gameObject.transform.position = targets[rand].transform.position;

                foreach (GameObject obj in targets)
                {
                    obj.SendMessage("cool");
                }

                //collision.gameObject.SendMessage("landing");
                */

                collision.gameObject.transform.position = targetPortal.transform.position;
                targetPortal.SendMessage("cool");
            }
        }
    }

    private void cool()
    {
        cooldown = 1;
    }
}
