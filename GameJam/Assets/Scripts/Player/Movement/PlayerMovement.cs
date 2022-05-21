using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameObject player = null;
    private Rigidbody2D rig = null;
    private Vector2 deltaForce;

    [SerializeField] private float speed = 5f;

    void Awake()
    {
        player = GameObject.Find("Player");
        rig = GetComponent<Rigidbody2D>();
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
        CalculateMovement(deltaForce * speed);
    }

    private void CalculateMovement(Vector2 force)
    {
        rig.velocity = Vector2.zero;
        rig.AddForce(force, ForceMode2D.Impulse);
    }




















}
