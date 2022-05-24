using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealthAmount = 50;
    [SerializeField] private float immunityTime = 0.5f;
    [SerializeField] bool isPlayer = false;

    private float healthAmount;
    bool isImmune = false;

    public bool isAlive = true;

    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        healthAmount = maxHealthAmount;
        if (transform.CompareTag(TagManager.PLAYER_TAG))
        {
            healthSlider.value = 1;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (isImmune) return;

        healthAmount -= damageAmount;
        StartCoroutine(MakeImmune());
        StartCoroutine(DamageEffects());

        if(isPlayer)
        {
            healthSlider.value = healthAmount / maxHealthAmount;
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
        yield return new WaitForSeconds(immunityTime);
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
        if(transform.parent) transform.parent.gameObject.SetActive(false);
        else gameObject.SetActive(false);
    }
}
