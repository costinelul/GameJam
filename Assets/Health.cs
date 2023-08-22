using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

    }

    public void TakeDamage()
    {
        currentHealth -= 10;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        healthbar.SetHealth(currentHealth);
        Debug.Log(currentHealth);
    }
}
