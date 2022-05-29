using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointReached : MonoBehaviour
{
    private Transform ben;
    public bool isWayPoint1 = false;

    // Start is called before the first frame update
    void Start()
    {
        ben = GameObject.Find("Ben").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(ben.position, transform.position) < 3 )
        {
            if(isWayPoint1)
            {
                ben.GetComponent<BenMovement>().isWayPoint1 = false;
                ben.GetComponent<BenMovement>().isWayPoint2 = true;
            }
            else
            {
                ben.GetComponent<BenMovement>().isWayPoint1 = true;
                ben.GetComponent<BenMovement>().isWayPoint2 = false;
            }
        }
    }
}
