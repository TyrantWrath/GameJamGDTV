using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealthAmount = 50;

    private float healthAmount;
    bool isPlayer = false;
    bool isImmune = false;

    public bool isAlive = true;

    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        healthAmount = maxHealthAmount;
        if (transform.CompareTag(TagManager.PLAYER_TAG))
        {
            isPlayer = true;
            healthSlider.value = healthAmount;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isPlayer && isImmune) return;

        healthAmount -= damageAmount;
        StartCoroutine(MakeImmune());
        StartCoroutine(DamageEffects());

        if(isPlayer)
        {
            healthSlider.value = healthAmount;
        }
        if (healthAmount <= 0)
        {
            isAlive = false;
            Die();
        }
    }
    IEnumerator MakeImmune()
    {
        isImmune = true;
        yield return new WaitForSeconds(0.5f);
        isImmune = false;
    }
    IEnumerator DamageEffects()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        Color orignalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.15f);

        spriteRenderer.color = orignalColor;
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }
}
