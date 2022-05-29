using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenRotation : MonoBehaviour
{
    private BenMovement benMovement;
    private Transform wayPoint;
    private Vector3 direction;
    private float angleDirection;

    // Start is called before the first frame update
    void Start()
    {
        benMovement = GetComponentInParent<BenMovement>();
    }

    void Update()
    {
        GetDirection();
        RotateSprite();
    }

    private void RotateSprite()
    {
        direction = (wayPoint.position - transform.position).normalized;
        direction.z = 0;

        angleDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDirection + 90, Vector3.forward);
    }

    private void GetDirection()
    {
        wayPoint = benMovement.ReturnDirection();
    }
}
