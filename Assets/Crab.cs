using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crab : MonoBehaviour
{
    public float Health = 100f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage()
    {
        Health -= 10;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(Health);
    }
}
