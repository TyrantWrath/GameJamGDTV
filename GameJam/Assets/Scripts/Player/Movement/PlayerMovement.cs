using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameObject player = null;
    public Rigidbody2D rb = null;
    private Vector2 deltaForce;

    [SerializeField] private float speed = 5f;

    void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        CheckForMovement();
    }

    private void CheckForMovement()
    {
        var horizontalMovement = Input.GetAxisRaw("Horizontal");
        var verticalMovement = Input.GetAxisRaw("Vertical");

        deltaForce = new Vector2(horizontalMovement, verticalMovement);
        rb.velocity = deltaForce * speed;
        //CalculateMovement(deltaForce * speed);
    }

    private void CalculateMovement(Vector2 force)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(force, ForceMode2D.Impulse);
    }




















}
