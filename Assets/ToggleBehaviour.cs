using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleBehaviour : MonoBehaviour
{
    public bool isUsingPowerUp = false;
    public float multiplier = 2f;
    PlayerMovement stats;
    Health health;

    [SerializeField] float damage = 1f;

    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerMovement>();
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    void Update()
    {
        UsePowerUp();

        if (isUsingPowerUp)
        {
            health.TakeDamage(damage * Time.deltaTime);
        }
    }

    void UsePowerUp()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame)
        {
            if (isUsingPowerUp == true)
            {
                stats.speed /= multiplier;
                stats.jump /= multiplier;

                isUsingPowerUp = false;
                Debug.Log("PowerUp deactivated");
            }
            else
            {
                stats.speed *= multiplier;
                stats.jump *= multiplier;

                isUsingPowerUp = true;
                Debug.Log("Is Using PowerUp");
            }
        }
    }
}
