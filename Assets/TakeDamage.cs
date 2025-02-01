using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float maxHealth = 1f;
    public float currentHealth;
    
    public HealthBar healthBar;
    
    public GameObject parrent;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GameObject().GetComponent<Bullet>() != null && !other.CompareTag("EnemyBullet"))
        {
            if (currentHealth <= 0f)
            {
                Destroy(parrent);
            }
            TakeDamage1();
        }
    }

    public void TakeDamage1()
    {
        currentHealth -= 0.1f;
            
        healthBar.setHealth(currentHealth);
    }
}
