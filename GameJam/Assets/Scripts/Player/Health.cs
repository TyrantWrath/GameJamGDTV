using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealthAmount = 50;

    private float healthAmount;
    public bool isAlive = true;

    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        healthAmount = maxHealthAmount;
        if (transform.CompareTag(TagManager.PLAYER_TAG))
        {
            healthSlider.value = healthAmount;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        healthAmount -= damageAmount;

        if(transform.CompareTag(TagManager.PLAYER_TAG))
        {
            healthSlider.value = healthAmount;
        }
        if (healthAmount <= 0)
        {
            isAlive = false;
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
