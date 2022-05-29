using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenMovement : MonoBehaviour
{

    [SerializeField] private Transform wayPoint1 = null;
    [SerializeField] private Transform wayPoint2 = null;
    public bool isWayPoint1 = true;
    public bool isWayPoint2 = false;
    public float speed = 5f;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isWayPoint1)
        {
            direction = (wayPoint1.position - transform.position).normalized;
            direction.z = 0;
        }
        if(isWayPoint2)
        {
            direction = (wayPoint2.position - transform.position).normalized;
            direction.z = 0;
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public Transform ReturnDirection()
    {
        if(isWayPoint1)
        {
            return wayPoint1;
        }
        else
        {
            return wayPoint2;
        }
    }
}
