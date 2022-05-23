using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    Rigidbody2D rb;

    private Transform player = null;
    private Vector3 playerDirection;

    [SerializeField] private float speed = 8f;
    [SerializeField] private int damage = 15;
       
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;

        rb = GetComponent<Rigidbody2D>();

        RotateSprite();
    }
    void FixedUpdate()
    {
        rb.velocity = -transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            collision.GetComponentInParent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private void RotateSprite()
    {
        playerDirection = (player.position - transform.position).normalized;
        playerDirection.z = 0;

        float angleDirection = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDirection + 90, Vector3.forward);
    }
}
