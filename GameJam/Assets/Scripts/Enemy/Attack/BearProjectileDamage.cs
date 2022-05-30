using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearProjectileDamage : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private Transform player = null;
    public float rotationSpeed = 2f;
    [SerializeField] private int damage = 15;

    [Space(25)]
    [Header("CameraShake")]

    [Range(0f, 1f)]
    [SerializeField] float cameraShakeIntensityHitAttack = 0.5f;

    [Range(0f, 2f)]
    [SerializeField] float cameraShakeDurationHitAttack = 0.2f;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == player)
        {
            CameraShake.Instance.ShakeCamera(cameraShakeIntensityHitAttack, cameraShakeDurationHitAttack);
            collision.GetComponentInParent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag(TagManager.ARROW_TAG))
        {
            Destroy(gameObject);
        }
    }

}
