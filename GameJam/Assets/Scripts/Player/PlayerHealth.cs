using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealthAmount;
    [SerializeField] private float healthAmount;
    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        healthAmount = maxHealthAmount;
        healthSlider.value = healthAmount;
    }

    public void TakeDamage(float damageAmount)
    {
        healthAmount -= damageAmount;
    }

    private void Update()
    {/*
        //For test only, Remove ASAP
        if (Input.GetMouseButtonDown(1))
        {
            healthAmount -= 15;
        }*/

        healthSlider.value = healthAmount;

        if(healthAmount <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }
}
