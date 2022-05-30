using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    Rigidbody2D rb;

    private Transform player = null;
    private Vector3 playerDirection;

    public float speed = 8f;
    [SerializeField] private int damage = 15;

    [Space(25)]
    [Header("CameraShake")]

    [Range(0f, 1f)]
    [SerializeField] float cameraShakeIntensityHitAttack = 0.5f;

    [Range(0f, 2f)]
    [SerializeField] float cameraShakeDurationHitAttack = 0.2f;

    void Start()
    {
        if (transform.CompareTag(TagManager.REAL_ENEMY_TAG))
        {
            player = FindObjectOfType<PlayerModeManager>().realInstance.transform;
        }
        else if (transform.CompareTag(TagManager.GHOST_ENEMY_TAG))
        {
            player = FindObjectOfType<PlayerModeManager>().ghostInstance.transform;
        }

        rb = GetComponent<Rigidbody2D>();
        WorldSlowDown worldSlowDown = FindObjectOfType<WorldSlowDown>();

        if (worldSlowDown.currentMap == MapSwap.ghostWorld && !gameObject.CompareTag(TagManager.GHOST_ENEMY_TAG))
        {
            speed /= worldSlowDown.slowFactor;
        }

        RotateSprite();

        Destroy(gameObject, 5);
    }
    void FixedUpdate()
    {
        rb.velocity = -transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == player)
        {
            CameraShake.Instance.ShakeCamera(cameraShakeDurationHitAttack, cameraShakeDurationHitAttack);
            collision.GetComponentInParent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag(TagManager.ARROW_TAG))
        {
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
