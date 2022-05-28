using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealthAmount = 50;
    [SerializeField] private float immunityTime = 0.5f;
    [SerializeField] bool isPlayer = false;

    private float healthAmount;
    bool isImmune = false;
    Color orignalColor;
    SpriteRenderer spriteRenderer;

    public bool isAlive = true;

    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        healthAmount = maxHealthAmount;
        UpdateSlider();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        orignalColor = spriteRenderer.color;
    }

    private void UpdateSlider()
    {
        if (isPlayer)
        {
            healthSlider.value = healthAmount / maxHealthAmount;
        }
    }
    public void Heal(int healAmount)
    {
        healthAmount += healAmount;
        UpdateSlider();
    }

    public void TakeDamage(int damageAmount)
    {
        if (isImmune) return;

        healthAmount -= damageAmount;
        StartCoroutine(MakeImmune());
        StartCoroutine(DamageEffects());

        UpdateSlider();
        if (healthAmount <= 0)
        {
            isAlive = false;
            Die();
        }
    }
    public void ResetHealth()
    {
        healthAmount = maxHealthAmount;
        isAlive = true;
        isImmune = false;
        if(orignalColor != null) spriteRenderer.color = orignalColor;
        
        GetComponentInChildren<Animator>().SetBool("IsDead", false);
        foreach (MonoBehaviour script in GetComponentsInChildren<MonoBehaviour>())
        {
            if (script != this)
            {
                script.enabled = true;
            }
        }
        foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
        {
            collider.enabled = false;
        }
        UpdateSlider();
    }
    IEnumerator MakeImmune()
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityTime);
        isImmune = false;
    }
    IEnumerator DamageEffects()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.15f);

        spriteRenderer.color = orignalColor;
    }
    private void Die()
    {
        if(!isPlayer)
        {
            Animator animator = GetComponentInChildren<Animator>();
            animator.SetBool("IsDead", true);

            foreach(MonoBehaviour script in GetComponentsInChildren<MonoBehaviour>())
            {
                if(script != this)
                {
                    script.enabled = false;
                }
            }
            GetComponentInChildren<Rigidbody2D>().velocity = Vector2.zero;
            foreach(Collider2D collider in GetComponentsInChildren<Collider2D>())
            {
                collider.enabled = false;
            }
        }
    }
}
