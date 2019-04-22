using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent;

        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Magnitude(player.localPosition - transform.localPosition) )

        transform.localPosition += new Vector3(player.localPosition.x - transform.localPosition.x, player.localPosition.y - transform.localPosition.y, 0) * Time.deltaTime;
    }
}
