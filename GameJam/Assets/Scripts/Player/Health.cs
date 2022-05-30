using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (isPlayer && healthSlider != null)
        {
            healthSlider.value = healthAmount;
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
        if (orignalColor != null) spriteRenderer.color = orignalColor;

        GetComponentInChildren<Animator>().SetBool("IsDead", false);
        EnableEnemyScripts(true);
        foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
        {
            collider.enabled = true;
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
        if (transform.GetComponent<DestroyThisGameObject>())
        {
            transform.GetComponent<DestroyThisGameObject>().DestroyThisGameObjectMethod();
        }
        if (!isPlayer)
        {
            Animator animator = GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.SetBool("IsDead", true);
            }
            EnableEnemyScripts(false);

            Rigidbody2D rb = GetComponentInChildren<Rigidbody2D>();
            if (rb == null) rb = GetComponentInParent<Rigidbody2D>();
            rb.velocity = Vector2.zero;

            foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
            {
                collider.enabled = false;
            }
        }
        else if (isPlayer)
        {
            StartCoroutine(PlayerDeathDelay());
        }
    }
    IEnumerator PlayerDeathDelay()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("GameOver");
    }

    public void EnableEnemyScripts(bool state)
    {
        foreach (MonoBehaviour script in GetComponentsInChildren<MonoBehaviour>())
        {
            if (script != this)
            {
                script.enabled = state;
            }
        }
        if (transform.parent && transform.parent.GetComponent<EnemyBearMovement>())
        {
            transform.parent.GetComponent<EnemyBearMovement>().enabled = state;
        }
    }
}
