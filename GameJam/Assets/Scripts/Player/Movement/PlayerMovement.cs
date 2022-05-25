using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;

    [SerializeField] private float speed = 5f;

    float orignalSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        orignalSpeed = speed;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - 90);

        if (movement.x != 0 && movement.y != 0)
        {
            speed = orignalSpeed * 0.7f;
        }
        else
        {
            speed = orignalSpeed;
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
