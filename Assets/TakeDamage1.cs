using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeDamage1 : MonoBehaviour
{
    public float maxHealth = 1f;
    public float currentHealth;
    
    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GameObject().GetComponent<Bullet>() != null)
        {
            if (currentHealth <= 0f)
            {
                Destroy(gameObject);
            }
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 0.1f;
            
        healthBar.setHealth(currentHealth);
    }
}
