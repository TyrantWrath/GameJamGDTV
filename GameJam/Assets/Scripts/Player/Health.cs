using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealthAmount;
    [SerializeField] private float healthAmount;
    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        if(transform.CompareTag(TagManager.PLAYER_TAG))
        {
            healthAmount = maxHealthAmount;
            healthSlider.value = healthAmount;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        healthAmount -= damageAmount;

        if(transform.CompareTag(TagManager.PLAYER_TAG))
        {
            healthSlider.value = healthAmount;
        }
        if (healthAmount <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }
}
